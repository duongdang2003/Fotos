using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class ShopItemController : Controller
    {
        // GET: ShopItem
<<<<<<< HEAD
        public ActionResult Index()
        {
=======
        public ActionResult Index(string productName, string description)
        {
            ViewBag.ProductName = productName;
            ViewBag.Description = description;
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
            return View();
        }
    }
}