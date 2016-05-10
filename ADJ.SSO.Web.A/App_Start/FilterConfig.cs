using System.Web;
using System.Web.Mvc;

namespace ADJ.SSO.Web.A
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
