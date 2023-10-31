using System.Web;
using System.Web.Mvc;

namespace _20_09_23_MvcLoginAndRegistration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
