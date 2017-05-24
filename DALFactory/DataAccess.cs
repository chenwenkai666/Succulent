﻿using System;
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
        public static ISucculent CreateSucculent()
        {
            string className = assemblyName + "." + db + "Succulent";
            return (ISucculent)Assembly.Load(assemblyName).CreateInstance(className);
        }
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
        public static ISucculentCategory CreateSucculentCategory()
        {
            string className = assemblyName + "." + db + "SucculentCategory";
            return (ISucculentCategory)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IGoodsComments CreateGoodsComments()
        {
            string className = assemblyName + "." + db + "GoodsComments";
            return (IGoodsComments)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IActivity CreateActivity()
        {
            string className = assemblyName + "." + db + "Activity";
            return (IActivity)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IAttendance CreateAttendance()
        {
            string className = assemblyName + "." + db + "Attendance";
            return (IAttendance)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IEntries CreateEntries()
        {
            string className = assemblyName + "." + db + "Entries";
            return (IEntries)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IDonate CreateDonate()
        {
            string className = assemblyName + "." + db + "Donate";
            return (IDonate)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IAdopt CreateAdopt()
        {
            string className = assemblyName + "." + db + "Adopt";
            return (IAdopt)Assembly.Load(assemblyName).CreateInstance(className);
        }
        public static IAdoptResult CreateAdoptResult()
        {
            string className = assemblyName + "." + db + "AdoptResult";
            return (IAdoptResult)Assembly.Load(assemblyName).CreateInstance(className);
        }
    }
}
