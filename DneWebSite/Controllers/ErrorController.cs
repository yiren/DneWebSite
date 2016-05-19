using DneWebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DneWebSite.Controllers
{
    public class ErrorController : Controller
    {
        private ApplicationUserManager _userManager;
        public ErrorController()
        {

        }
        public ErrorController(ApplicationUserManager userManager)
        {

            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Posts
        // GET: Error
 
        public ActionResult Index()
        {
            ViewBag.Message = "您可能進行不正常操作，請洽系統管理員。";
            return View();
        }

        public ActionResult BadRequest()
        {
            ViewBag.Message = "您可能進行不正常操作，請重新操作，請洽系統管理員。";
            return View();
        }

        public ActionResult NoPermission()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            ViewBag.Message = "您沒有足夠的權限，請洽系統管理員。";
            return View(user);
        }

        public ActionResult InternalError()
        {
            ViewBag.Message = "伺服器主機有問題，請洽系統管理員。";
            return View();
        }
    }
}