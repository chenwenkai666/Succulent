using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Reflection;
using System.Configuration;
namespace DALFactory
{
  public  class DataAccess
    {
        private static string assemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IGoods CreateGoods()
        {
            string className = assemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IShops CreateShops()
        {
            string className = assemblyName + "." + db + "Shops";
            return (IShops)Assembly.Load(assemblyName).CreateInstance(className);
        }
    }
}
