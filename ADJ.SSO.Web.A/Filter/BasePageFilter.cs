using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ServiceStack.Redis;
using ADJ.SSO.Common;

namespace ADJ.SSO.Web.A.Filter
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