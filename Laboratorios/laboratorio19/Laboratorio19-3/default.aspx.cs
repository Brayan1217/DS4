using System;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio19_3
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Tomar el ID ingresado
            string id = TextBox1.Text.Trim();

            // URL del API
            string url = $"https://localhost:44372/api/values/{id}"; // cambia el puerto

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Obtener JSON
                    var json = response.Content.ReadAsStringAsync().Result;

                    // Como devuelve un solo string → deserializamos string
                    var valor = JsonConvert.DeserializeObject<string>(json);

                    Label1.Text = "Resultado: " + valor;
                }
                else
                {
                    Label1.Text = "Error: No se encontró el ID.";
                }
            }
        }
    }
}
