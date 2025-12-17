using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proyecto1
{
    public partial class Calculadora : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        string operacion = "";
        bool nuevaOperacion = false;
        string connectionString = @"Server=.\SQLEXPRESS;Database=CalculadoraBD;TrustServerCertificate=True;Integrated Security=True;";


        public Calculadora()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e) => AgregarNumero("1");
        private void btn2_Click(object sender, EventArgs e) => AgregarNumero("2");
        private void btn3_Click(object sender, EventArgs e) => AgregarNumero("3");
        private void btn4_Click(object sender, EventArgs e) => AgregarNumero("4");
        private void btn5_Click(object sender, EventArgs e) => AgregarNumero("5");
        private void btn6_Click(object sender, EventArgs e) => AgregarNumero("6");
        private void btn7_Click(object sender, EventArgs e) => AgregarNumero("7");
        private void btn8_Click(object sender, EventArgs e) => AgregarNumero("8");
        private void btn9_Click(object sender, EventArgs e) => AgregarNumero("9");
        private void btn0_Click(object sender, EventArgs e) => AgregarNumero("0");

        //  Botones de operación
        private void btnSum_Click(object sender, EventArgs e) => GuardarOperacion("+");
        private void btnRes_Click(object sender, EventArgs e) => GuardarOperacion("-");
        private void btnMultipli_Click(object sender, EventArgs e) => GuardarOperacion("*");
        private void btnDivi_Click(object sender, EventArgs e) => GuardarOperacion("/");
        private void btnPotenci_Click(object sender, EventArgs e) => GuardarOperacion("^");


        //  Calcular resultado
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(Pantalla.Text, out valor2))
            {
                MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double resultado = 0;

            switch (operacion)
            {
                case "+": resultado = valor1 + valor2; break;
                case "-": resultado = valor1 - valor2; break;
                case "*": resultado = valor1 * valor2; break;
                case "/":
                    if (valor2 == 0)
                    {
                        MessageBox.Show("No se puede dividir entre 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    resultado = valor1 / valor2;
                    break;
                case "^": resultado = Math.Pow(valor1, valor2); break;
                default:
                    MessageBox.Show("Selecciona una operación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            Pantalla.Text = resultado.ToString();
            nuevaOperacion = true;

            // Guardar en la base de datos
            GuardarEnBaseDeDatos($"{valor1} {operacion} {valor2}", resultado);
        }

        //  Raíz cuadrada
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Pantalla.Text, out valor1))
            {
                if (valor1 >= 0)
                {
                    Pantalla.Text = Math.Sqrt(valor1).ToString();
                    nuevaOperacion = true;
                }
                else
                {
                    MessageBox.Show("No se puede calcular la raíz de un número negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //  Borrar último dígito
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Pantalla.Text.Length > 0)
                Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
        }

        //  Borrar todo
        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            Pantalla.Clear();
            valor1 = 0;
            valor2 = 0;
            operacion = "";
        }

        private void GuardarEnBaseDeDatos(string operacionTexto, double resultado)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Calculos (Operacion, Resultado) VALUES (@Operacion, @Resultado)";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Operacion", operacionTexto);
                        comando.Parameters.AddWithValue("@Resultado", resultado);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
         //Evento genérico para números
        private void AgregarNumero(string numero)
        {
            if (nuevaOperacion)
            {
                Pantalla.Text = "";
                nuevaOperacion = false;
            }

            Pantalla.Text += numero;
        }

        private void GuardarOperacion(string op)
        {
            if (double.TryParse(Pantalla.Text, out valor1))
            {
                operacion = op;
                Pantalla.Clear();
            }
            else
            {
                MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
