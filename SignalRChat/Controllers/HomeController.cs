using SignalRChat.HubClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 群聊主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 判断是否是新用户
            var cookieUserName = Request.Cookies["USERNAME"];
            if (cookieUserName == null) // 如果是新用户，则跳转到新用户页面
            {
                return RedirectToAction("NewUser");
            }
            ViewBag.UserName = HttpUtility.UrlDecode(cookieUserName.Value);
            return View();
        }

        /// <summary>
        /// 新用户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewUser()
        {
            return View();
        }

        /// <summary>
        /// 把用户名存入cookie，然后跳转到首页
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewUser(string userName)
        {
            Response.Cookies.Add(new HttpCookie("USERNAME", HttpUtility.UrlEncode(userName)));
            return Redirect("/");
        }

        /// <summary>
        /// 发送系统消息页面，主动发送
        /// </summary>
        /// <returns></returns>
        public ActionResult SendSystemMsg()
        {
            return View();
        }


        /// <summary>
        /// 发送系统方法
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        public string SendSystemMsg(string msg)
        {
            GroupChat.Instance.SendSystemMsg(msg);
            return "s";
        }

    }
}