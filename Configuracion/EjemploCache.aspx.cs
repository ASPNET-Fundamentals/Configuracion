using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Configuracion
{
    public partial class EjemploCache : System.Web.UI.Page
    {
        CacheItemRemovedCallback onRemove = null;

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {            
            string reason = r.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["dato"] == null)
            {
                string fileContent = File.ReadAllText(Server.MapPath("~/EjemploCache.txt"));

                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                

                Cache.Insert
                (
                    "dato",
                    fileContent,
                    new CacheDependency(Server.MapPath("~/EjemploCache.txt")),
                    DateTime.Now.AddMinutes(1),
                    TimeSpan.Zero,
                    CacheItemPriority.High,
                    onRemove
                );
            }

            Response.Write(string.Concat("Value Cache: ", Cache["dato"]));
            Response.Write("<BR/>");
        }
    }
}