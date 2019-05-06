using System.Web;
using System.Web.Mvc;

namespace IEProject_AfterIteration1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
