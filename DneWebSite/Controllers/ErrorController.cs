using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DneWebSite.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.Message = "您可能進行不正常操作，請洽系統管理員。";
            return View();
        }

        public ActionResult BadRequest()
        {
            ViewBag.Message = "您可能進行不正常操作，請洽系統管理員。";
            return View();
        }

        public ActionResult NoPermission()
        {
            ViewBag.Message = "您沒有足夠的權限，請洽系統管理員。";
            return View();
        }

        public ActionResult InternalError()
        {
            ViewBag.Message = "伺服器主機有問題，請洽系統管理員。";
            return View();
        }
    }
}