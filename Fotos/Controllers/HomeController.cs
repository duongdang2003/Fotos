using Fotos.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Fotos.Controllers
{
    public class HomeController : Controller
    {
        private bool IsUserLoggedIn = false;
        public ActionResult Index()
        {
            /*if (IsUserLoggedIn)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }*/
            var username = SessionHelper.GetSession().username;
            ViewBag.Username = username;
            System.Diagnostics.Debug.WriteLine(username);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}