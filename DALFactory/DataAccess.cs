using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    public class DataAccess
    {
        private static string assemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();

        public static IUsers CreateUsers()
      {
          string className = assemblyName + "." + db + "Users";
           return (IUsers)Assembly.Load(assemblyName).CreateInstance(className);
      }
    }
}
