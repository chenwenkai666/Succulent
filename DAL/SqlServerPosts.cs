﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using IDAL;

namespace DAL
{
    public class SqlServerPosts : IPosts
    {
        SucculentEntities db = new SucculentEntities();

        public IEnumerable<Sections> GetSection03()    //获取前三个板块
        {
            var data = (from p in db.Sections select p).OrderBy(p => p.SectionID).Take(3);
            return data;
        }
        public IEnumerable<Sections> GetSection06()   //获取后六个板块
        {
            var data = (from p in db.Sections select p).OrderBy(p => p.SectionID).Skip(3).Take(6);
            return data;
        }
        public IEnumerable<Sections> GetSectionName(int boardID)  //获取板块名称
        {
            var data = from p in db.Sections
                       where p.SectionID == boardID
                       select p;
            return data;
        }
        public IEnumerable<Posts> GetSectionPost(int boardID)  //获取板块帖子
        {
            var data = (from p in db.Posts
                        join user in db.Users
                        on p.UserID equals user.UserID
                        where p.SectionID == boardID
                        select p).OrderByDescending(p => p.PublishTime);
            return data;
        }
        public IEnumerable<Posts> GetPostDetails(int PostID)  //获取帖子详情
        {
            var data = from p in db.Posts
                       join user in db.Users on p.UserID equals user.UserID
                       where p.PostID == PostID
                       select p;
            return data;
        }
        public IEnumerable<PostComments> GetPostComments(int PostID)  //获取帖子评论
        {
            var data = (from p in db.PostComments.AsNoTracking()
                        join user in db.Users on p.UserID equals user.UserID
                        where p.PostID == PostID
                        select p).OrderBy(p => p.PostCommentTime);
            return data;
        }
        public int GetReplyComNum(int PostCommentID)   //获取回复数量
        {
            var q = db.ReplyPost.Count(p => p.PostCommentID == PostCommentID);
            return q;
        }
        public int GetPostNumberAll(int boardID)  //获取板块总帖数
        {
            var q = db.Posts.Count(p => p.SectionID == boardID);
            return q;
        }
        public int GetPostNumberToday(int boardID)  //获取板块今日帖数
        {
            DateTime dtToday = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime dtNexDay = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            var q = db.Posts.Count(p => p.SectionID == boardID && p.PublishTime >= dtToday && p.PublishTime < dtNexDay);
            return q;
        }
        public int GetAllPostNum()  //获取所有帖子数量
        {
            var q = db.Posts.Count();
            return q;
        }
        public int GetTodayPostNum()  //获取今日帖子数量
        {
            DateTime dtToday = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime dtNexDay = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            var q = db.Posts.Count(p => p.PublishTime >= dtToday && p.PublishTime < dtNexDay);
            return q;
        }
        public int GetYesterdayPostNum()  //获取昨日帖子数量
        {
            DateTime dtLastday = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            DateTime dtToDay = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            var q = db.Posts.Count(p => p.PublishTime >= dtLastday && p.PublishTime < dtToDay);
            return q;
        }
        public IEnumerable<Users> SelectUserInfo(string UserName)  //查询用户信息
        {
            var data = from p in db.Users
                       where p.UserName == UserName
                       select p;
            return data;
        }
    }
}
