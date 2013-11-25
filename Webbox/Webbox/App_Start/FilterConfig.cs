using System.Web.Mvc;
using Webbox.Core.Web.Profiling;

namespace Webbox
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}