using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio203
{
    public partial class _Default : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["cnProductos"].ConnectionString;

        // Aquí guardamos si estamos en modo "nuevo" usando ViewState
        bool nuevo
        {
            get { return (bool?)ViewState["nuevo"] ?? false; }
            set { ViewState["nuevo"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HabilitarCampos(false);
                HabilitarBotones(inicial: true);
            }
        }

        // ------------ Helpers de habilitar / limpiar ------------

        void HabilitarCampos(bool habilitar)
        {
            txtId.Enabled = !habilitar; // ID solo cuando se busca
            txtNombre.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtStock.Enabled = habilitar;
        }

        void HabilitarBotones(bool inicial)
        {
            // inicial = true: solo se puede Nuevo y Buscar
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;

            btnGuardar.Enabled = !inicial;
            btnCancelar.Enabled = !inicial;
            btnEliminar.Enabled = !inicial;
        }

        void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            tstId.Text = "";
            lblMensaje.Text = "";
        }

        // ---------------------- Botón Nuevo ----------------------

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            LimpiarCampos();
            HabilitarCampos(true);
            HabilitarBotones(inicial: false);
            txtNombre.Focus();
        }

        // ---------------------- Botón Guardar -------------------

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (nuevo)
                {
                    cmd.CommandText = @"INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK)
                                        VALUES (@nombre, @precio, @stock)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE LAPTOPS
                                        SET NOMBRE = @nombre,
                                            PRECIO = @precio,
                                            STOCK = @stock
                                        WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                }

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMensaje.Text = nuevo
                            ? "Registro ingresado correctamente."
                            : "Registro actualizado correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "No se realizaron cambios.";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

            nuevo = false;
            HabilitarCampos(false);
            HabilitarBotones(inicial: true);
        }

        // ---------------------- Botón Cancelar ------------------

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            LimpiarCampos();
            HabilitarCampos(false);
            HabilitarBotones(inicial: true);
        }

        // ---------------------- Botón Eliminar ------------------

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM LAPTOPS WHERE ID = @id", con);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        lblMensaje.Text = "Registro eliminado correctamente.";
                        LimpiarCampos();
                        HabilitarCampos(false);
                        HabilitarBotones(inicial: true);
                    }
                    else
                    {
                        lblMensaje.Text = "No existe un registro con ese ID.";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        // ---------------------- Botón Buscar --------------------

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM LAPTOPS WHERE ID = @id", con);
                cmd.Parameters.AddWithValue("@id", tstId.Text);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtId.Text = reader["ID"].ToString();
                        txtNombre.Text = reader["NOMBRE"].ToString();
                        txtPrecio.Text = reader["PRECIO"].ToString();
                        txtStock.Text = reader["STOCK"].ToString();

                        // Vamos a modo edición (update)
                        nuevo = false;
                        HabilitarCampos(true);
                        HabilitarBotones(inicial: false);
                        txtNombre.Focus();
                    }
                    else
                    {
                        lblMensaje.Text = "Ningún registro encontrado con el ID ingresado.";
                        LimpiarCampos();
                        HabilitarCampos(false);
                        HabilitarBotones(inicial: true);
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

            tstId.Text = "";
        }

        // ---------------------- Botón Salir ---------------------

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            // En web no "cerramos" la app, normalmente redirigimos
            Response.Redirect("https://www.google.com"); // o a otra página de tu sitio
        }
    }
}