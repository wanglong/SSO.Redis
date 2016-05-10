using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADJ.SSO.Web.A.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            PassportService pass = new PassportService();
            ViewData["userName"] = pass.GetUserInfo().UserName;
            return View();
        }

    }
}