using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class ShopItemController : Controller
    {
        // GET: ShopItem
        public ActionResult Index(string userName, string productName, string description, string picture, string date, string ownerName, string numberOfPhotos, string email)
        {
            ViewBag.UserName = userName;
            ViewBag.ProductName = productName;
            ViewBag.Description = description;
            ViewBag.Picture = picture;

            var dateDetail = date.Split(' ');
            ViewBag.Date = dateDetail[0];

            ViewBag.OwnerName = ownerName;
            ViewBag.NumberOfPhotos = numberOfPhotos;
            ViewBag.Email = email;
            return View();
        }
    }
}