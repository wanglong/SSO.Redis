using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADJ.SSO.Web
{
    public partial class Quit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tokenValue = Common.Common.GetCookie("token");
            Common.Common.AddCookie("token",tokenValue,-1);
            HttpContext.Current.Response.Redirect(ConfigurationManager.AppSettings["DefaultUrl"]);
        }
    }
}