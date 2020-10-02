using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Configuracion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ejemploKey = ConfigurationManager.AppSettings["EjemploKey"];
            string ejemploKeyExternal = ConfigurationManager.AppSettings["EjemploKeyExternal"];
            string stringConnection = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            Response.Write(string.Concat("Value Key EjemploKey: ", ejemploKey));
            Response.Write("<BR/>");
            Response.Write(string.Concat("Valor Key EjemploKeyExternal: ", ejemploKeyExternal));
            Response.Write("<BR/>");
            Response.Write(string.Concat("Value Key stringConnection: ", stringConnection));            
        }
    }
}