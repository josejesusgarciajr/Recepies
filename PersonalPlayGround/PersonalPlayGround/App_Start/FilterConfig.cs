using PersonalPlayGround.Filters;
using System.Web.Mvc;

namespace PersonalPlayGround
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // default
            filters.Add(new GlobalExceptionHandler()); // custom
        }
    }
}
