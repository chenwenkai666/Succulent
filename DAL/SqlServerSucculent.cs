﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
   public  class SqlServerSucculent:ISucculent
    {
        SucculentEntities db = new SucculentEntities();

    }
}
