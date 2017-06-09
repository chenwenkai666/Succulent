using System;
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

        public IEnumerable<Sections> GetSection03() //获取前三个板块
        {
            var data = (from p in db.Sections select p).OrderBy(p => p.SectionID).Take(3);
            return data;
        }
        public IEnumerable<Sections> GetSection06()   //获取后六个板块
        {
            var data = (from p in db.Sections select p).OrderBy(p => p.SectionID).Skip(3).Take(6);
            return data;
        }
        public IEnumerable<Sections> GetSection33() //获取第三个板块
        {
            var data = (from p in db.Sections select p).OrderBy(p => p.SectionID).Skip(2).Take(1);
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
        public Posts GetPostDetails(int PostID)  //获取帖子详情
        {
            var data =db.Posts.Where(p=>p.PostID==PostID).FirstOrDefault();
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
        public Posts SelectPostFirstFloor(int userid, DateTime time)  //查找帖子一楼
        {
            Posts data = (from p in db.Posts
                          where p.UserID == userid && p.PublishTime == time
                          select p).FirstOrDefault();
            return data;
        }
        public IEnumerable<Users> SelectInfoUsers(string postinfo)  //搜索帖子
        {
            var data = (from p in db.Users
                        where p.UserName.Contains(postinfo)
                        select p).ToList().OrderBy(i => Guid.NewGuid()).ToList();
            return data;
        }
        public IEnumerable<Posts> SelectInfoPosts(string postinfo)  //搜索帖子
        {
            var data = (from p in db.Posts
                        where p.PostTitle.Contains(postinfo)
                        select p).OrderByDescending(p => p.PublishTime);
            return data;
        }
        public IEnumerable<PostComments> SelectInfoPostCom(string postinfo)  //搜索帖子
        {
            var data = (from p in db.PostComments
                        where p.PostCommentContent.Contains(postinfo)
                        select p).OrderByDescending(p => p.PostCommentTime);
            return data;
        }
        public IEnumerable<ReplyPost> SelectInfoReplyPost(string postinfo)  //搜索帖子
        {
            var data = (from p in db.ReplyPost
                        where p.ReplyContent.Contains(postinfo)
                        select p).OrderByDescending(p => p.ReplyPostTime);
            return data;
        }
        public int GetPostComNum(int PostID)  //获取评论数量
        {
            int q = db.PostComments.Count(p => p.PostID == PostID);
            return q;
        }
        public int SelectSectionID(string SectionName) //获取板块ID
        {
            int q = (from p in db.Sections
                     where p.SectionName == SectionName
                     select p.SectionID).FirstOrDefault();
            return q;
        }
        public IEnumerable<Level> SelectUserLevel(int userid)  //搜索用户等级
        {
            int level = (from p in db.Pots
                         where p.UserID == userid
                         select p.LevelID).FirstOrDefault();
            var lev = from b in db.Level
                      where b.LevelID == level
                      select b;
            return lev;
        }
        public IEnumerable<Posts> SelectAllPosts()
        {
            return db.Posts.ToList();
        }
        public Users GetUserFlag(int userid)   //获取用户权限ID
        {
            Users data = (from p in db.Users
                          where p.UserID == userid
                          select p).FirstOrDefault();
            return data;
        }
        public int GetUserPotLev(int userid)    //获取用户有无花盆
        {
            int q = db.Pots.Count(p => p.UserID == userid);
            return q;
        }
        public int GetUserEx(int userid)   //获取用户经验
        {
            int exp = (from p in db.Pots
                       where p.UserID == userid
                       select p.Experience).FirstOrDefault();
            return exp;
        }
        public IEnumerable<Posts> SelectIndexPost01()   //首页帖子显示01
        {
            var data = (from p in db.Posts select p).ToList().OrderBy(i => Guid.NewGuid()).ToList().Take(7);
            return data;
        }
        public IEnumerable<Posts> SelectIndexPost02()   //首页帖子显示02
        {
            var data = (from p in db.Posts select p).OrderByDescending(p => p.PublishTime).Take(7);
            return data;
        }
        public IEnumerable<PostComments> SelectIndexPost03()   //首页帖子显示03
        {
            var data = (from p in db.PostComments select p).OrderByDescending(p => p.PostCommentTime).Take(7);
            return data;
        }
        public IEnumerable<Posts> SelectAllPostsByUserID(int UserID)//获取用户发表的所有帖子
        {
            return db.Posts.Where(p=>p.UserID==UserID).ToList();
        }
    }
}