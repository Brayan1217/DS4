using System.Data.SqlClient;

namespace parcial2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-EF8UT5E;Initial Catalog=Conversiones;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValor.Text == "")
                    MessageBox.Show("Por favor ingrese un valor.");

                // verifica  si es negativo
                double valor = Convert.ToDouble(txtValor.Text);
                if (valor < 0)
                    MessageBox.Show("Ingrese un valor positivo.");

                //convert
                double resultado = valor * 1.0936133;
                txtResultado.Text = resultado.ToString("N2");

                //sql connex
                string sql = "INSERT INTO Conversiones (Valor,Resultado ) VALUES (@Valor,@Resultado)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Insertado correctamente");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de número inválido. Por favor ingrese un número válido.");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtyardas.Text == "")
                    MessageBox.Show("Por favor ingrese un valor.");

                double yardas = Convert.ToDouble(txtyardas.Text);
                if (yardas < 0)
                    MessageBox.Show("Ingrese un valor positivo.");

                //conversion
                double resultado = yardas / 1.0936133;
                textBox4.Text = resultado.ToString("N2");

                //conectar ak sql
                string sql = "INSERT INTO Conversiones (Valor,Resultado) VALUES (@Valor,@Resultado)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandText = sql;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Insertado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de número inválido. Por favor ingrese un número válido.");

            }
        }
    }
}

