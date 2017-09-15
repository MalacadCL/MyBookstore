using System.Web;
using System.Web.Mvc;

namespace MyBookstore_MalacadCL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
