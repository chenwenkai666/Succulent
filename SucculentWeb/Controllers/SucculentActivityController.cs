using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using System.IO;
using SucculentWeb.ViewModels;
using PagedList;
using SucculentWeb.Attributes;

namespace SucculentWeb.Controllers
{
    public class SucculentActivityController : Controller
    {
        AdoptResultManager adoptresultmanager = new AdoptResultManager();
        GoodsManager goodsmanager = new GoodsManager();
        ShopManager shopmanager = new ShopManager();
        ActivityManager activitymanager = new ActivityManager();
        UsersManager usermanager = new UsersManager();
        DonateManager donatemanager = new DonateManager();
        AdoptManager adoptmanager = new AdoptManager();
        EntriesManager entriesmanager = new EntriesManager();
        AttendanceManager attendancemanager = new AttendanceManager();
        // GET: SucculentActivity
        #region 活动首页
        //public ActionResult Index()
        //{
        //    ActivityIndexVM ActIndexVM = new ActivityIndexVM();
        //    var actPhotograph = ActivityManager.GetActivityByCategoryID(1);
        //    var actDIY = ActivityManager.GetActivityByCategoryID(2);
        //    var actAdopt = ActivityManager.GetActivityByCategoryID(3);
        //    var actCharitable = ActivityManager.GetActivityByCategoryID(4);

        //    ActIndexVM.PhotographActivity = actPhotograph;
        //    ActIndexVM.DIYActivity = actDIY;
        //    ActIndexVM.AdoptActivity = actAdopt;
        //    ActIndexVM.CharitableActivity = actCharitable;

        //    return View(ActIndexVM);
        //}

        public ActionResult Index()/*int? page*/
        {
            //int pageSize = 1;
            //int pageNum = (page ?? 1);

            //ActivityIndexVM ActIndexVM = new ActivityIndexVM();
            //var actPhotograph = ActivityManager.GetActivityByCategoryID(1);
            //var actDIY = ActivityManager.GetActivityByCategoryID(2);
            //var actAdopt = ActivityManager.GetActivityByCategoryID(3);
            //var actCharitable = ActivityManager.GetActivityByCategoryID(4);

            //ActIndexVM.PhotographActivity = actPhotograph.ToPagedList(pageNum,pageSize);
            //ActIndexVM.DIYActivity = actDIY.ToPagedList(pageNum, pageSize);
            //ActIndexVM.AdoptActivity = actAdopt.ToPagedList(pageNum, pageSize);
            //ActIndexVM.CharitableActivity = actCharitable.ToPagedList(pageNum, pageSize);

            //decimal totalPages= ((decimal)(ActIndexVM.PhotographActivity.Count() / (decimal)pageSize));
            //ViewBag.OneOfPhotographActivity = ActIndexVM.PhotographActivity;
            //ViewBag.pagenum = pageNum;
            //ViewBag.TotalPages = Math.Ceiling(totalPages);

            return View();/*ActIndexVM*/
        }
        #endregion

        #region 摄影、DIY大赛活动详情
        public ActionResult Details(int id = 1)
        {
            DateTime nowtime = DateTime.Now;
            Activity act = activitymanager.GetActivity(id);
            if (nowtime > act.EndTime)
            {
                return Content("<script>alert('活动已结束');window.location='" + Url.Action("Index", "SucculentActivity") + "'</script>");
            }
            else
            {
                if (act.ActivityCategoryID == 1 || act.ActivityCategoryID == 2)
                {
                    return View(act);
                }
                else if (act.ActivityCategoryID == 3)
                {
                    return RedirectToAction("AdoptDetail", new {id= id} );
                }
                else
                {
                    return RedirectToAction("CharitableDetail", new { ActID = id });
                }
            }

        }
        #endregion

        #region 慈善活动详情
        public ActionResult CharitableDetail(int ActID = 5)
        {
            Activity act = activitymanager.GetActivity(ActID);
            return View(act);
        }
        #endregion

        #region 捐赠填写信息页面
        public ActionResult Donate(int ActID)
        {
            try
            {
                Users user = usermanager.GetUserByName(Session["UserName"].ToString());
                int actid = ActID;
                int UserID = user.UserID;
                Donate donate = donatemanager.GetUserDonate(UserID, ActID);
                return View(donate);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return Content("<script>alert('请先登录');window.location='" + Url.Action("Login", "User") + "'</script>");
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Donate(Donate donate)
        {
            try
            {
                Users user = usermanager.GetUserByName(Session["UserName"].ToString());
                donate.UserID = user.UserID;
                donate.DonateTime = DateTime.Now;
                donate.ActivityID = int.Parse(Request.Form["actid"]);
                donate.DonateState = "待收货";
                if (donatemanager.InsertDonate(donate))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "0";
            }

        }
        #endregion

        #region 领养活动详情
        public ActionResult AdoptDetail(int id = 6)
        {
            AdoptSucculentVM AdoptVM = new AdoptSucculentVM();
            AdoptVM.Activity = activitymanager.GetActivity(id);
            AdoptVM.AdoptList = adoptmanager.GetAdoptListByActID(id);
            AdoptVM.AdoptResult = adoptresultmanager.GetAdoptResultByActID(id);

            return View(AdoptVM);
        }
        #endregion

        #region 商家增加可领养多肉列表页面
        public ActionResult AddAdoptSucculentList(int ActID = 1)
        {
            try
            {
                if (Session["UserName"].ToString() != "")
                {
                    Users user = usermanager.GetUserByName(Session["UserName"].ToString());
                    Activity act = activitymanager.GetActivity(ActID);
                    if (user.UserFlag == 1 && act.UserID == user.UserID)
                    {
                        Shops shop = shopmanager.GetShopByUserID(user.UserID);
                        AdoptListAddVM adoptadd = new AdoptListAddVM();
                        adoptadd.Activity = act;
                        adoptadd.Shops = shop;
                        adoptadd.Goods = goodsmanager.SelectShopDuorouZhiwu(shop.ShopID);
                        return View(adoptadd);
                    }
                    else
                    {
                        return Content("<script>alert('抱歉，您权限不足！');history.go(-1);</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('请先登录');window.location='" + Url.Action("Login", "User") + "'</script>");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return Content("<script>alert('系统出错');window.location='" + Url.Action("Login", "User") + "'</script>");
            }


        }

        [HttpPost]
        public ActionResult AddAdoptSucculentList()
        {
            string[] goodsid = Request.Params.GetValues("goodsid");
            string[] total = Request.Params.GetValues("Total");
            string[] actid = Request.Params.GetValues("actid");
            for (int i = 0; i < goodsid.Length; i++)
            {
                Adopt adopt = new Adopt();
                adopt.ActivityID = int.Parse(actid[i]);
                adopt.GoodsID = int.Parse(goodsid[i]);
                adopt.Total = int.Parse(total[i]);
                if (adoptmanager.InsertAdopt(adopt))
                {

                }
                else
                {
                    break;
                }
            }
            return Content("<script>alert('提交成功，感谢您的支持~');window.location='" + Url.Action("Index", "SucculentActivity") + "'</script>");
        }
        #endregion

        #region 活动发布
        public ActionResult Publish()
        {
            IList<ActivityCategory> activityCategory = activitymanager.GetActivityCategory();

            ViewBag.ActivityCategory = new SelectList(activityCategory, "ActivityCategoryID", "ActivityCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Publish(Activity act)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];//判断是否已经选择上传文件
                string filePath = file.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string path = Server.MapPath(@"\images\Activity\Cover\" + DateTime.Now.ToString("yyyyMMdd") + "\\");
                if (!Directory.Exists(path))//判断路径是否存在，若不存在则创建
                {
                    Directory.CreateDirectory(path);
                }
                string serverpath = path + filename;
                string relativepath = @"/images/Activity/Cover/" + DateTime.Now.ToString("yyyyMMdd") + "/" + filename;
                file.SaveAs(serverpath);//上传路径

                act.ActivityCover = relativepath;

                act.ActivityCategoryID = int.Parse(Request.Form["ActivityCategory"]);
                act.UpvoteNum = 0;
                if (activitymanager.InsertActivity(act))
                {
                    return Content("<script>alert('发布成功！');window.open('" + Url.Action("Index", "SucculentActivity") + "', '_self')</script>");
                }
                else
                {
                    return Content("<script>alert('对不起，发布失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                return Content("<script>alert('系统出错，发布失败！原因如下：" + ex.Message + "');window.open('" + Url.Action("Publish", "SucculentActivity") + "', '_self')</script>");
            }
        }
        #endregion

        #region 异步获取主办方名称
        public string GetUserName(string UserID)
        {
            int userid = int.Parse(UserID);
            Users user = usermanager.GetUserByID(userid);
            if (user != null)
            {
                return user.UserName;
            }
            else
            {
                return "不存在该用户";
            }
        }
        #endregion

        #region 登录遮罩分部页
        [ChildActionOnly]
        public ActionResult OverlayLogin()
        {
            return PartialView();
        }
        #endregion

        #region 用户报名参与比赛
        public string Attend(int ActivityID)
        {
            try
            {
                if (Session["UserName"].ToString() != "")
                {
                    int level = usermanager.GetUserLevel(Session["UserName"].ToString());
                    Users user = usermanager.GetUserByName(Session["UserName"].ToString());
                    Activity act = activitymanager.GetActivity(ActivityID);
                    bool UserAttend = attendancemanager.IsAttendActivity(user.UserID, ActivityID);
                    if (user != null && !UserAttend && level >= act.LevelRequest)
                    {
                        Attendance attendance = new Attendance();
                        attendance.ActivityID = ActivityID;
                        attendance.UserID = user.UserID;
                        attendance.AttendanceTime = DateTime.Now;
                        attendancemanager.InsertAttendance(attendance);
                        return "报名成功";
                    }
                    else if (UserAttend)
                    {
                        return "您已报过名啦，去上传作品吧~";
                    }
                    else
                    {
                        return "对不起，您不满足参赛条件！";
                    }
                }
                else
                {
                    return "请先登录！";
                }
            }
            catch (Exception ex)
            {
                return "抱歉，系统出错！错误信息：" + ex.Message + "请稍后再试..";
            }
        }
        #endregion

        #region 参与活动页面
        public ActionResult AttendPhotoActivity(int actID)
        {
            var entries = entriesmanager.GetAllEntriesByActID(actID);
            return View(entries);
        }
        #endregion

        #region 活动列表分布页
        [ChildActionOnly]
        public ActionResult PatialActivityList(int? page, int ACid = 1)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var acts = activitymanager.GetActivityByCategoryID(ACid);
            if (Request.IsAjaxRequest())
            {
                return PartialView("PatialActivityList", acts.OrderBy(a => a.ActivityID).ToPagedList(pageNum, pageSize));
            }
            else
            {
                return View("PatialActivityList", acts.OrderBy(a => a.ActivityID).ToPagedList(pageNum, pageSize));
            }
        }
        #endregion

        #region 图片作品发表
        [HttpPost]
        [IsLogIn(IsCheck =true)]
        public ActionResult UploadPortfolio()/*string TextDescription*/
        {
            int ActID = int.Parse(Request.Form["actID"].ToString());
            Users user = usermanager.GetUserByName(Session["UserName"].ToString());
            bool IsAttendance = attendancemanager.IsAttendActivity(user.UserID, ActID);
            if (IsAttendance)
            {
                if (!entriesmanager.IsPublishEntry(user.UserID, ActID))
                {
                    try
                    {

                        Activity act = activitymanager.GetActivity(ActID);
                        HttpPostedFileBase file = Request.Files["filePortfolio"];//判断是否已经选择上传文件
                        string filePath = file.FileName;
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string path = Server.MapPath(@"\images\Activity\Portfolio\" + act.ActivityID + "\\");
                        if (!Directory.Exists(path))//判断路径是否存在，若不存在则创建
                        {
                            Directory.CreateDirectory(path);
                        }
                        string serverpath = path + filename;
                        string relativepath = @"/images/Activity/Portfolio/" + act.ActivityID + "/" + filename;
                        file.SaveAs(serverpath);//上传路径

                        Entries entries = new Entries();
                        entries.ActivityID = ActID;
                        entries.Image = relativepath;
                        entries.TextDescription = Request.Form["TextDescription"];
                        entries.JoinTime = DateTime.Now;
                        entries.UserID = user.UserID;
                        entries.UpvoteNum = 0;
                        if (entriesmanager.InsertEntries(entries))
                        {
                            return Content("<script>alert('发布成功！');window.open('" + Url.Action("AttendPhotoActivity", "SucculentActivity", new { actID = ActID }) + "', '_self')</script>");
                        }
                        else
                        {
                            return Content("<script>alert('对不起，发布失败！');window.open('" + Url.Action("AttendPhotoActivity", "SucculentActivity", new { actID = ActID }) + "', '_self')')</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        return Content("<script>alert('系统出错，发布失败！原因如下：" + ex.Message + "');;window.open('" + Url.Action("AttendPhotoActivity", "SucculentActivity", new { actID = ActID }) + "', '_self')')</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('您已经发表过作品了，欣赏下他人作品吧~');window.open('" + Url.Action("AttendPhotoActivity", "SucculentActivity", new { actID = ActID }) + "', '_self')')</script>");
                }
            }
            else
            {
                return Content("<script>alert('您没有报名本活动哦~快去报名参加或去看看大家的作品吧');window.open('" + Url.Action("AttendPhotoActivity", "SucculentActivity", new { actID = ActID }) + "', '_self')')</script>");
            }
        }
        #endregion

        #region 异步判断用户是否已经上传过作品
        [HttpPost]
        public string IsPublish(string ActID)
        {
            if (Session["UserName"] != null)
            {
                Users user = usermanager.GetUserByName(Session["UserName"].ToString());
                int actid = int.Parse(ActID);
                bool IsAttendance = attendancemanager.IsAttendActivity(user.UserID, actid);
                if (IsAttendance)
                {

                    if (!entriesmanager.IsPublishEntry(user.UserID, actid))
                    {
                        return "0";
                    }
                    else
                    {
                        return "1";
                    }
                }
                else
                {
                    return "您没有报名本活动哦~快去报名参加或去看看大家的作品吧";
                }
            }
            else
            {
                return "2";
            }
        }
        #endregion

        #region 用户投票
        [HttpPost]
        public string Vote(int UserID, int ActID)
        {
            if (Session["UserName"] != null)
            {
                if (entriesmanager.AddUpvoteNum(UserID, ActID))
                {
                    return "1";
                }
                else
                {
                    return "系统出错";
                }
            }
            else
            {
                return "请您先登录！";
            }
        }
        #endregion 

        #region 摄影、DIY大赛评选结果作品展示
        public ActionResult PhotoResult()
        {
            var entry = entriesmanager.GetAllEntriesByActID(1).OrderByDescending(e => e.UpvoteNum);
            return View(entry);
        }
        #endregion
    }
}