using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SistemaReservas.API.Controllers
{
    [RoutePrefix("api/reservas")]
    public class ReservasController : ApiController
    {
        private string connectionString = ConfigurationManager
            .ConnectionStrings["SistemaReservasDB"].ConnectionString;

        [HttpGet]
        [Route("clientes")]
        public IHttpActionResult ObtenerClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT ClienteID, Nombre, Email, Telefono, FechaRegistro, Activo 
                                    FROM Clientes 
                                    WHERE Activo = 1 
                                    ORDER BY FechaRegistro DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            });
                        }
                    }
                }

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public IHttpActionResult ObtenerCliente(int id)
        {
            try
            {
                Cliente cliente = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT ClienteID, Nombre, Email, Telefono, FechaRegistro, Activo FROM Clientes WHERE ClienteID = @ClienteID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClienteID", id);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                        }
                    }
                }

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("clientes")]
        public IHttpActionResult RegistrarCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null || string.IsNullOrWhiteSpace(clienteDto.Nombre))
                    return BadRequest("Los datos del cliente son inválidos");

                int clienteID = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Clientes (Nombre, Email, Telefono) 
                                    VALUES (@Nombre, @Email, @Telefono);
                                    SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", clienteDto.Nombre);
                    cmd.Parameters.AddWithValue("@Email", clienteDto.Email);
                    cmd.Parameters.AddWithValue("@Telefono", clienteDto.Telefono ?? "");

                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    clienteID = Convert.ToInt32(result);
                }

                var cliente = new Cliente
                {
                    ClienteID = clienteID,
                    Nombre = clienteDto.Nombre,
                    Email = clienteDto.Email,
                    Telefono = clienteDto.Telefono,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                return Ok(cliente);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("duplicate") || ex.Message.Contains("UNIQUE"))
                {
                    return BadRequest("Ya existe un cliente con ese email");
                }
                return InternalServerError(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult ObtenerReservas()
        {
            try
            {
                List<object> reservas = new List<object>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        r.ReservaID, r.ClienteID, r.Fecha, r.HoraInicio, r.HoraFin,
                                        r.Descripcion, r.Estado, r.FechaCreacion,
                                        c.Nombre as NombreCliente, c.Email, c.Telefono
                                    FROM Reservas r
                                    INNER JOIN Clientes c ON r.ClienteID = c.ClienteID
                                    ORDER BY r.Fecha DESC, r.HoraInicio DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new
                            {
                                ReservaID = Convert.ToInt32(reader["ReservaID"]),
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                                HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                            });
                        }
                    }
                }

                return Ok(reservas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CrearReserva([FromBody] ReservaDto reservaDto)
        {
            try
            {
                if (reservaDto == null)
                    return BadRequest("Los datos de la reserva son inválidos");

                if (reservaDto.FechaReserva < DateTime.Today)
                    return BadRequest("No se pueden hacer reservas para fechas pasadas");

                if (reservaDto.HoraFin <= reservaDto.HoraInicio)
                    return BadRequest("La hora de fin debe ser posterior a la hora de inicio");

                if (!VerificarDisponibilidad(reservaDto.FechaReserva, reservaDto.HoraInicio, reservaDto.HoraFin))
                {
                    return BadRequest("Ya existe una reserva en ese horario");
                }

                int reservaID = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Reservas (ClienteID, Fecha, HoraInicio, HoraFin, Descripcion, Estado)
                                    VALUES (@ClienteID, @Fecha, @HoraInicio, @HoraFin, @Descripcion, 'Activa');
                                    SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ClienteID", reservaDto.ClienteId);
                    cmd.Parameters.AddWithValue("@Fecha", reservaDto.FechaReserva);
                    cmd.Parameters.AddWithValue("@HoraInicio", reservaDto.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", reservaDto.HoraFin);
                    cmd.Parameters.AddWithValue("@Descripcion", reservaDto.Observaciones ?? "");

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    reservaID = Convert.ToInt32(result);
                }

                var reserva = new
                {
                    ReservaID = reservaID,
                    ClienteID = reservaDto.ClienteId,
                    Fecha = reservaDto.FechaReserva,
                    HoraInicio = reservaDto.HoraInicio,
                    HoraFin = reservaDto.HoraFin,
                    Descripcion = reservaDto.Observaciones,
                    Estado = "Activa"
                };

                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id}/cancelar")]
        public IHttpActionResult CancelarReserva(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Reservas SET Estado = 'Cancelada' WHERE ReservaID = @ReservaID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReservaID", id);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                        return NotFound();
                }

                return Ok(new { mensaje = "Reserva cancelada exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("disponibilidad")]
        public IHttpActionResult ConsultarDisponibilidad(DateTime fecha, string horaInicio, string horaFin)
        {
            try
            {
                TimeSpan inicio, fin;
                if (!TimeSpan.TryParse(horaInicio, out inicio) || !TimeSpan.TryParse(horaFin, out fin))
                    return BadRequest("Formato de hora inválido");

                if (fin <= inicio)
                    return BadRequest("La hora de fin debe ser posterior a la hora de inicio");

                bool disponible = VerificarDisponibilidad(fecha, inicio, fin);

                return Ok(new
                {
                    fecha = fecha.ToString("yyyy-MM-dd"),
                    horaInicio,
                    horaFin,
                    disponible
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("reportes/dashboard")]
        public IHttpActionResult Dashboard()
        {
            try
            {
                var dashboard = new
                {
                    totalClientes = 0,
                    totalReservas = 0,
                    reservasActivas = 0,
                    reservasCanceladas = 0,
                    reservasHoy = 0
                };

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            (SELECT COUNT(*) FROM Clientes WHERE Activo = 1) as TotalClientes,
                            (SELECT COUNT(*) FROM Reservas) as TotalReservas,
                            (SELECT COUNT(*) FROM Reservas WHERE Estado = 'Activa') as ReservasActivas,
                            (SELECT COUNT(*) FROM Reservas WHERE Estado = 'Cancelada') as ReservasCanceladas,
                            (SELECT COUNT(*) FROM Reservas WHERE Fecha = CAST(GETDATE() AS DATE) AND Estado = 'Activa') as ReservasHoy";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dashboard = new
                            {
                                totalClientes = Convert.ToInt32(reader["TotalClientes"]),
                                totalReservas = Convert.ToInt32(reader["TotalReservas"]),
                                reservasActivas = Convert.ToInt32(reader["ReservasActivas"]),
                                reservasCanceladas = Convert.ToInt32(reader["ReservasCanceladas"]),
                                reservasHoy = Convert.ToInt32(reader["ReservasHoy"])
                            };
                        }
                    }
                }

                return Ok(dashboard);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("reportes/por-mes")]
        public IHttpActionResult ReportePorMes(int mes, int anio)
        {
            try
            {
                List<object> reservasMes = new List<object>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        r.ReservaID, r.ClienteID, r.Fecha, r.HoraInicio, r.HoraFin,
                                        r.Descripcion, r.Estado,
                                        c.Nombre as NombreCliente
                                    FROM Reservas r
                                    INNER JOIN Clientes c ON r.ClienteID = c.ClienteID
                                    WHERE MONTH(r.Fecha) = @Mes AND YEAR(r.Fecha) = @Anio
                                    ORDER BY r.Fecha, r.HoraInicio";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Anio", anio);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservasMes.Add(new
                            {
                                ReservaID = Convert.ToInt32(reader["ReservaID"]),
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                ClienteNombre = reader["NombreCliente"].ToString(),
                                FechaReserva = Convert.ToDateTime(reader["Fecha"]),
                                HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                                HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString()),
                                NumeroPersonas = 0,
                                TipoServicio = reader["Descripcion"].ToString(),
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }
                }

                var estadisticas = new
                {
                    totalReservas = reservasMes.Count,
                    reservasActivas = reservasMes.Count(r => ((dynamic)r).Estado == "Activa"),
                    reservasCanceladas = reservasMes.Count(r => ((dynamic)r).Estado == "Cancelada"),
                    reservas = reservasMes
                };

                return Ok(estadisticas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("reportes/clientes/{clienteId}")]
        public IHttpActionResult ReportePorCliente(int clienteId)
        {
            try
            {
                Cliente cliente = null;
                List<object> reservasCliente = new List<object>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string queryCliente = "SELECT ClienteID, Nombre, Email, Telefono, FechaRegistro FROM Clientes WHERE ClienteID = @ClienteID";
                    SqlCommand cmdCliente = new SqlCommand(queryCliente, conn);
                    cmdCliente.Parameters.AddWithValue("@ClienteID", clienteId);

                    conn.Open();

                    using (SqlDataReader reader = cmdCliente.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            };
                        }
                    }

                    if (cliente == null)
                        return NotFound();

                    string queryReservas = @"SELECT ReservaID, Fecha, HoraInicio, HoraFin, Descripcion, Estado
                                            FROM Reservas
                                            WHERE ClienteID = @ClienteID
                                            ORDER BY Fecha DESC";

                    SqlCommand cmdReservas = new SqlCommand(queryReservas, conn);
                    cmdReservas.Parameters.AddWithValue("@ClienteID", clienteId);

                    using (SqlDataReader reader = cmdReservas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservasCliente.Add(new
                            {
                                ReservaID = Convert.ToInt32(reader["ReservaID"]),
                                FechaReserva = Convert.ToDateTime(reader["Fecha"]),
                                HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                                HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString()),
                                NumeroPersonas = 0,
                                TipoServicio = reader["Descripcion"].ToString(),
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }
                }

                var reporte = new
                {
                    cliente = new
                    {
                        cliente.ClienteID,
                        cliente.Nombre,
                        cliente.Email,
                        cliente.Telefono,
                        cliente.FechaRegistro
                    },
                    estadisticas = new
                    {
                        totalReservas = reservasCliente.Count,
                        reservasActivas = reservasCliente.Count(r => ((dynamic)r).Estado == "Activa"),
                        reservasCanceladas = reservasCliente.Count(r => ((dynamic)r).Estado == "Cancelada")
                    },
                    reservas = reservasCliente
                };

                return Ok(reporte);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private bool VerificarDisponibilidad(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT COUNT(*) 
                                    FROM Reservas 
                                    WHERE Fecha = @Fecha 
                                    AND Estado = 'Activa'
                                    AND (
                                        (@HoraInicio >= HoraInicio AND @HoraInicio < HoraFin)
                                        OR (@HoraFin > HoraInicio AND @HoraFin <= HoraFin)
                                        OR (@HoraInicio <= HoraInicio AND @HoraFin >= HoraFin)
                                    )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
                    cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", horaFin);

                    conn.Open();
                    int conflictos = Convert.ToInt32(cmd.ExecuteScalar());

                    return conflictos == 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }

    public class Reserva
    {
        public int ReservaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }

    public class ReservaDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Observaciones { get; set; }
    }
}