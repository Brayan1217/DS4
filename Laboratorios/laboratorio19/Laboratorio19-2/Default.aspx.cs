using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

using Newtonsoft.Json;

namespace Laboratorio19_2
{
            using System.Net.Http;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44338/api/values"; // reemplaza puerto

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    // Deserializar a arreglo de strings
                    var valores = JsonConvert.DeserializeObject<string[]>(json);

                    // Mostrar resultado
                    Label1.Text = string.Join(", ", valores);
                }
                else
                {
                    Label1.Text = "Error al llamar el API.";
                }
            }
        }
    }
}