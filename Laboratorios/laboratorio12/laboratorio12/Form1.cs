namespace laboratorio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double distancia, tiempo, velocidad;
            velocidad = Convert.ToDouble(textBox1.Text);
            tiempo = Convert.ToDouble(textBox2.Text);
            distancia = velocidad * tiempo;
            textBox3.Text = Convert.ToString(distancia);
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
