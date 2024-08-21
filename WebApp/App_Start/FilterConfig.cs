using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class FilterConfig : FilterAttribute
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
