using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using DALFactory;
using IDAL;

namespace BLL
{
    public class PostsManager
    {
        public static IPosts iposts = DataAccess.CreatePosts();

        public static IEnumerable<Sections> GetSection03()    //获取前三个板块
        {
            return iposts.GetSection03();
        }
        public static IEnumerable<Sections> GetSection06()   //获取后六个板块
        {
            return iposts.GetSection06();
        }
        public static IEnumerable<Sections> GetSectionName(int boardID)  //获取板块名称
        {
            return iposts.GetSectionName(boardID);
        }
        public static IEnumerable<Posts> GetSectionPost(int boardID)  //获取板块帖子
        {
            return iposts.GetSectionPost(boardID);
        }
        public static IEnumerable<Posts> GetPostDetails(int PostID)  //获取帖子详情
        {
            return iposts.GetPostDetails(PostID);
        }
        public static IEnumerable<PostComments> GetPostComments(int PostID)  //获取帖子评论
        {
            return iposts.GetPostComments(PostID);
        }
        public static int GetReplyComNum(int PostCommentID)   //获取回复数量
        {
            return iposts.GetReplyComNum(PostCommentID);
        }
        public static int GetPostNumberAll(int boardID)  //获取板块总帖数
        {
            return iposts.GetPostNumberAll(boardID);
        }
        public static int GetPostNumberToday(int boardID)  //获取板块今日帖数
        {
            return iposts.GetPostNumberToday(boardID);
        }
        public static int GetAllPostNum()  //获取所有帖子数量
        {
            return iposts.GetAllPostNum();
        }
        public static int GetTodayPostNum()  //获取今日帖子数量
        {
            return iposts.GetTodayPostNum();
        }
        public static int GetYesterdayPostNum()  //获取昨日帖子数量
        {
            return iposts.GetYesterdayPostNum();
        }
        public static IEnumerable<Users> SelectUserInfo(string UserName)  //查询用户信息
        {
            return iposts.SelectUserInfo(UserName);
        }
        public static Posts SelectPostFirstFloor(int userid, DateTime time)  //查找帖子一楼
        {
            return iposts.SelectPostFirstFloor(userid, time);
        }
    }
}

