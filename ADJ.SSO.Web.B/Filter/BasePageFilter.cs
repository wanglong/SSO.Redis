using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADJ.SSO.Web.B.Filter
{
    public class BasePageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            PassportService pass = new PassportService();
            pass.Run();
        }
    }
}