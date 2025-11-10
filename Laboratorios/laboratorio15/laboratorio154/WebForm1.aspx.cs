using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int suma, numero1, numero2;
            numero1 = Convert.ToInt32(TextBox1.Text);
            numero2 = Convert.ToInt32(TextBox2.Text);
            suma = numero1 + numero2;


            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "MessageBox", "window.alert('La suma es: " + suma + "');", true);

        }
    }
}