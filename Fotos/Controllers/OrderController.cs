using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string userName, string productName)
        {
            ViewBag.UserName = userName;
            ViewBag.ProductName = productName;
            return View();
        }
    }
}