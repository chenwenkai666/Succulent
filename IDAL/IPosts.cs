using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IPosts
    {
        IEnumerable<Sections> GetSection03(); //获取前三个板块
        IEnumerable<Sections> GetSection06(); //获取后六个板块
        IEnumerable<Sections> GetSection33(); //获取第三个板块
        IEnumerable<Sections> GetSectionName(int boardID);  //获取板块名称
        IEnumerable<Posts> GetSectionPost(int boardID);  //获取板块帖子
        Posts GetPostDetails(int PostID);  //获取帖子详情
        IEnumerable<PostComments> GetPostComments(int PostID);  //获取帖子评论
        int GetReplyComNum(int PostCommentID);   //获取回复数量
        int GetPostNumberAll(int boardID);  //获取板块总帖数
        int GetPostNumberToday(int boardID);  //获取板块今日帖数
        int GetAllPostNum();  //获取所有帖子数量
        int GetTodayPostNum();  //获取今日帖子数量
        int GetYesterdayPostNum();  //获取昨日帖子数量
        IEnumerable<Users> SelectUserInfo(string UserName);  //查询用户信息
        Posts SelectPostFirstFloor(int userid, DateTime time);  //查找帖子一楼
        IEnumerable<Users> SelectInfoUsers(string postinfo);  //搜索帖子
        IEnumerable<Posts> SelectInfoPosts(string postinfo);  //搜索帖子
        IEnumerable<PostComments> SelectInfoPostCom(string postinfo);  //搜索帖子
        IEnumerable<ReplyPost> SelectInfoReplyPost(string postinfo);  //搜索帖子
        int GetPostComNum(int PostID);  //获取评论数量
        int SelectSectionID(string SectionName); //获取板块ID
        IEnumerable<Level> SelectUserLevel(int userid);  //搜索用户等级
        IEnumerable<Posts> SelectAllPosts();//获取全部帖子
        Users GetUserFlag(int userid);   //获取用户权限ID
        int GetUserPotLev(int userid);    //获取用户有无花盆
        int GetUserEx(int userid);    //获取用户经验
        IEnumerable<Posts> SelectIndexPost01();   //首页帖子显示01
        IEnumerable<Posts> SelectIndexPost02();   //首页帖子显示02
        IEnumerable<PostComments> SelectIndexPost03();   //首页帖子显示03
        IEnumerable<Posts> SelectAllPostsByUserID(int UserID);//获取用户发表的所有帖子
    }
}