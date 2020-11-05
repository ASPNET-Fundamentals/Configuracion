using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Configuracion
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Se ejectura cuando inicia la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// se ejectura cuando se inicia la sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            if (Application["visitas"] == null)
            {
                Application["visitas"] = 1;
            }
            else
            {
                Application["visitas"] = ((int)Application["visitas"] + 1);
            }
            
            Session["sessionID"] = Session.SessionID;
        }


        /// <summary>
        /// Se ejecuta cuando se recibe una solicitud de aplicación. 
        /// Es el primer evento que se activa para una solicitud, que a menudo es una solicitud de página (URL) que ingresa un usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Se activa cuando el módulo de seguridad ha establecido la identidad del usuario actual como válida. 
        /// En este punto, se han validado las credenciales del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se ejectura cuando ocurre algun error en la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            HttpException httpEx = ex as HttpException;

            if (httpEx == null || httpEx.GetHttpCode() != 404)
            {
                Application["LastException"] = ex;
            }
        }
            


        /// <summary>
        /// Se ejectura cuando finaliza la sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Ss ejectura cuando finaliza la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}