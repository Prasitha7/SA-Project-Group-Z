using System.Web;
using System.Web.Mvc;

namespace SA_Group_Z__21._1_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
