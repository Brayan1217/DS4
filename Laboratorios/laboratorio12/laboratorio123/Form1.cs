namespace laboratorio123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_semiP_Click(object sender, EventArgs e)
        {
            double a, b, c, semiP;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            c = Convert.ToDouble(textBox3.Text);
            semiP = (a + b + c) / 2;
            textBox4.Text = Convert.ToString(semiP);
        }

        private void btn_area_Click(object sender, EventArgs e)
        {
            double a, b, c, area, semiP;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            c = Convert.ToDouble(textBox3.Text);
            semiP = (a + b + c) / 2;
            area = Math.Sqrt(semiP * (semiP - a) * (semiP - b) * (semiP - c));
            textBox5.Text = Convert.ToString(area);
        }
        private void btn_limpiar_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
