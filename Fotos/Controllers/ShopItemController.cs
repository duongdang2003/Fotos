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
        public ActionResult Index(string productName, string description)
        {
            ViewBag.ProductName = productName;
            ViewBag.Description = description;
            return View();
        }
    }
}