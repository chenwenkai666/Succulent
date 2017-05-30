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
        IEnumerable<Sections> GetSectionName(int boardID);  //获取板块名称
        IEnumerable<Posts> GetSectionPost(int boardID);  //获取板块帖子
        IEnumerable<Posts> GetPostDetails(int PostID);  //获取帖子详情
        IEnumerable<PostComments> GetPostComments(int PostID);  //获取帖子评论
        int GetReplyComNum(int PostCommentID);   //获取回复数量
        int GetPostNumberAll(int boardID);  //获取板块总帖数
        int GetPostNumberToday(int boardID);  //获取板块今日帖数
        int GetAllPostNum();  //获取所有帖子数量
        int GetTodayPostNum();  //获取今日帖子数量
        int GetYesterdayPostNum();  //获取昨日帖子数量
        IEnumerable<Users> SelectUserInfo(string UserName);  //查询用户信息
    }
}

