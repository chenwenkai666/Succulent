using SucculentWeb.Attributes;
using System.Web;
using System.Web.Mvc;

namespace SucculentWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new IsLogInAttribute() { IsCheck = false });
        }
    }
}
