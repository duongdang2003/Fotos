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
<<<<<<< HEAD
        public ActionResult Index()
        {
=======
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
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
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