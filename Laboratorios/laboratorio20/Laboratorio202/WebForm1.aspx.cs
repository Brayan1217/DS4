using System;

namespace Laboratorio202
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtN.Text);

            string tabla = "<table border='1' cellpadding='5'>";

            for (int i = 0; i < N; i++)
            {
                tabla += "<tr>";

                for (int j = 0; j < N; j++)
                {
                    int valor = (i + j == N - 1) ? 1 : 0; // diagonal inversa
                    tabla += $"<td>{valor}</td>";
                }

                tabla += "</tr>";
            }

            tabla += "</table>";

            ltMatriz.Text = tabla;
        }
    }
}
