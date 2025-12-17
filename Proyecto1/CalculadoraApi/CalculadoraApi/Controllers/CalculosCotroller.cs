using CalculadoraApi.Models;
using CalculadoraAPI.Models.WS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CalculadoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculosController : ControllerBase    
    {
        // String de conexión
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=CalculadoraBD;Trusted_Connection=True;MultipleActiveResultSets=true";

        // GET: api/Calculos/GetCalculos
        [HttpGet]
        public Reply GetCalculos()
        {
            Reply reply = new Reply();
            try
            {
                List<Calculo> calculos = new List<Calculo>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Operacion, Resultado FROM Calculos";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = (int)reader["Id"],
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = (decimal)reader["Resultado"]
                        });
                    }
                    reader.Close();
                }

                reply.Result = 200;
                reply.Data = calculos;
                reply.Message = "Datos obtenidos correctamente";
            }
            catch (Exception ex)
            {
                reply.Result = 500;
                reply.Data = null!;
                reply.Message = "Error: " + ex.Message;
            }

            return reply;
        }

        // GET: api/Calculos/GetSumas
        [HttpGet("GetSumas")]
        public Reply GetSumas()
        {
            Reply reply = new Reply();
            try
            {
                List<Calculo> calculos = new List<Calculo>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Operacion, Resultado FROM Calculos WHERE Operacion LIKE '%+%'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = (int)reader["Id"],
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = (decimal)reader["Resultado"]
                        });
                    }
                    reader.Close();
                }

                reply.Result = 200;
                reply.Data = calculos;
                reply.Message = "Sumas obtenidas correctamente";
            }
            catch (Exception ex)
            {
                reply.Result = 500;
                reply.Data = null!;
                reply.Message = "Error: " + ex.Message;
            }

            return reply;
        }

        // GET: api/Calculos/GetRestas
        [HttpGet("GetRestas")]
        public Reply GetRestas()
        {
            Reply reply = new Reply();
            try
            {
                List<Calculo> calculos = new List<Calculo>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Operacion, Resultado FROM Calculos WHERE Operacion LIKE '%-%'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = (int)reader["Id"],
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = (decimal)reader["Resultado"]
                        });
                    }
                    reader.Close();
                }

                reply.Result = 200;
                reply.Data = calculos;
                reply.Message = "Restas obtenidas correctamente";
            }
            catch (Exception ex)
            {
                reply.Result = 500;
                reply.Data = null!;
                reply.Message = "Error: " + ex.Message;
            }

            return reply;
        }

        // GET: api/Calculos/GetMultiplicaciones
        [HttpGet("GetMultiplicaciones")]
        public Reply GetMultiplicaciones()
        {
            Reply reply = new Reply();
            try
            {
                List<Calculo> calculos = new List<Calculo>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Operacion, Resultado FROM Calculos WHERE Operacion LIKE '%*%' OR Operacion LIKE '%×%'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = (int)reader["Id"],
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = (decimal)reader["Resultado"]
                        });
                    }
                    reader.Close();
                }

                reply.Result = 200;
                reply.Data = calculos;
                reply.Message = "Multiplicaciones obtenidas correctamente";
            }
            catch (Exception ex)
            {
                reply.Result = 500;
                reply.Data = null!;
                reply.Message = "Error: " + ex.Message;
            }

            return reply;
        }

        // GET: api/Calculos/GetDivisiones
        [HttpGet("GetDivisiones")]
        public Reply GetDivisiones()
        {
            Reply reply = new Reply();
            try
            {
                List<Calculo> calculos = new List<Calculo>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Operacion, Resultado FROM Calculos WHERE Operacion LIKE '%/%' OR Operacion LIKE '%÷%'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        calculos.Add(new Calculo
                        {
                            Id = (int)reader["Id"],
                            Operacion = reader["Operacion"].ToString(),
                            Resultado = (decimal)reader["Resultado"]
                        });
                    }
                    reader.Close();
                }

                reply.Result = 200;
                reply.Data = calculos;
                reply.Message = "Divisiones obtenidas correctamente";
            }
            catch (Exception ex)
            {
                reply.Result = 500;
                reply.Data = null!;
                reply.Message = "Error: " + ex.Message;
            }

            return reply;
        }
    }
}