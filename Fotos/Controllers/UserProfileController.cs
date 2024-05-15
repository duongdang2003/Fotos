using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        private int imageCount = 0;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Increase()
        {
            imageCount++;
            return null;
        }
    }
}