using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;

namespace DAL
{
    public class SqlServerPots:IPots
    {
        SucculentEntities db = new SucculentEntities();

        public bool InsertPots(Pots pots)
        {
            db.Pots.Add(pots);
            return db.SaveChanges() > 0;
        }
        public Pots GetPotsByUserID(int UserID)
        {
            return db.Pots.Where(p => p.UserID == UserID).FirstOrDefault();
        }
        public bool UpdateExperience(int UserID,int Exp)
        {
            Pots pot = GetPotsByUserID(UserID);
            pot.Experience += Exp;
            db.Entry(pot).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool PotsSign(int UserID)
        {
            Pots pot = GetPotsByUserID(UserID);
            DateTime oldsign;
            if (pot.Sign == null)
            {
                oldsign = DateTime.Parse("2000-01-01 00:00:00");
            }
            else
            {
                oldsign = DateTime.Parse(pot.Sign.ToString());//获取上次的签到日期
            }
            TimeSpan range = DateTime.Now - oldsign;//获取当前时间和上次签到日期的时间差
            int rangeDays = range.Days;//获取天数差
            pot.Sign = DateTime.Now;
            if (pot.SignDays==null ||rangeDays!=1)//新用户第一次签到或老用户间断签到，连续签到天数设置为0，经验+2
            {
                pot.SignDays = 0 ;
                pot.Experience += 2;
            }
            else if(pot.SignDays>=2 && rangeDays==1)//用户连续签到3天，经验+4
            {
                pot.SignDays += 1;
                pot.Experience += 4;
            }
            else
            {
                pot.SignDays += 1;
                pot.Experience += 2;
            }
            db.Entry(pot).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
