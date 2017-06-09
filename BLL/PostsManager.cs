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
        public IPosts iposts = DataAccess.CreatePosts();

        public IEnumerable<Sections> GetSection03() //获取前三个板块
        {
            return iposts.GetSection03();
        }
        public IEnumerable<Sections> GetSection06()   //获取后六个板块
        {
            return iposts.GetSection06();
        }
        public IEnumerable<Sections> GetSection33() //获取第三个板块
        {
            return iposts.GetSection33();
        }
        public IEnumerable<Sections> GetSectionName(int boardID)  //获取板块名称
        {
            return iposts.GetSectionName(boardID);
        }
        public IEnumerable<Posts> GetSectionPost(int boardID)  //获取板块帖子
        {
            return iposts.GetSectionPost(boardID);
        }
        public Posts GetPostDetails(int PostID)  //获取帖子详情
        {
            return iposts.GetPostDetails(PostID);
        }
        public IEnumerable<PostComments> GetPostComments(int PostID)  //获取帖子评论
        {
            return iposts.GetPostComments(PostID);
        }
        public int GetReplyComNum(int PostCommentID)   //获取回复数量
        {
            return iposts.GetReplyComNum(PostCommentID);
        }
        public int GetPostNumberAll(int boardID)  //获取板块总帖数
        {
            return iposts.GetPostNumberAll(boardID);
        }
        public int GetPostNumberToday(int boardID)  //获取板块今日帖数
        {
            return iposts.GetPostNumberToday(boardID);
        }
        public int GetAllPostNum()  //获取所有帖子数量
        {
            return iposts.GetAllPostNum();
        }
        public int GetTodayPostNum()  //获取今日帖子数量
        {
            return iposts.GetTodayPostNum();
        }
        public int GetYesterdayPostNum()  //获取昨日帖子数量
        {
            return iposts.GetYesterdayPostNum();
        }
        public IEnumerable<Users> SelectUserInfo(string UserName)  //查询用户信息
        {
            return iposts.SelectUserInfo(UserName);
        }
        public Posts SelectPostFirstFloor(int userid, DateTime time)  //查找帖子一楼
        {
            return iposts.SelectPostFirstFloor(userid, time);
        }
        public IEnumerable<Users> SelectInfoUsers(string postinfo)  //搜索帖子
        {
            return iposts.SelectInfoUsers(postinfo);
        }
        public IEnumerable<Posts> SelectInfoPosts(string postinfo)  //搜索帖子
        {
            return iposts.SelectInfoPosts(postinfo);
        }
        public IEnumerable<PostComments> SelectInfoPostCom(string postinfo)  //搜索帖子
        {
            return iposts.SelectInfoPostCom(postinfo);
        }
        public IEnumerable<ReplyPost> SelectInfoReplyPost(string postinfo)  //搜索帖子
        {
            return iposts.SelectInfoReplyPost(postinfo);
        }
        public int GetPostComNum(int PostID)  //获取评论数量
        {
            return iposts.GetPostComNum(PostID);
        }
        public int SelectSectionID(string SectionName) //获取板块ID
        {
            return iposts.SelectSectionID(SectionName);
        }
        public IEnumerable<Level> SelectUserLevel(int userid)  //搜索用户等级
        {
            return iposts.SelectUserLevel(userid);
        }
        public IEnumerable<Posts> SelectAllPosts()//获取全部帖子
        {
            return iposts.SelectAllPosts();
        }
        public Users GetUserFlag(int userid)   //获取用户权限ID
        {
            return iposts.GetUserFlag(userid);
        }
        public int GetUserPotLev(int userid)    //获取用户有无花盆
        {
            return iposts.GetUserPotLev(userid);
        }
        public int GetUserEx(int userid)   //获取用户经验
        {
            return iposts.GetUserEx(userid);
        }
        public IEnumerable<Posts> SelectIndexPost01()   //首页帖子显示01
        {
            return iposts.SelectIndexPost01();
        }
        public IEnumerable<Posts> SelectIndexPost02()   //首页帖子显示02
        {
            return iposts.SelectIndexPost02();
        }
        public IEnumerable<PostComments> SelectIndexPost03()   //首页帖子显示03
        {
            return iposts.SelectIndexPost03();
        }
        public IEnumerable<Posts> SelectAllPostsByUserID(int UserID)//获取用户发表的所有帖子
        {
            return iposts.SelectAllPostsByUserID(UserID);
        }
    }
}