namespace laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btn_calcularPromedio_Click(object sender, EventArgs e)
        {
            float nota1, nota2, nota3, promedio;
            nota1 = Convert.ToSingle(textBox1.Text);
            nota2 = Convert.ToSingle(textBox2.Text);
            nota3 = Convert.ToSingle(textBox3.Text);
            promedio = (nota1 + nota2 + nota3) / 3;
            textBox4.Text = Convert.ToString(promedio);
        }
    }
}
