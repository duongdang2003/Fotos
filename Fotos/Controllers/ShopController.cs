using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class ShopController : Controller
    {

        private FotosDbContext db = new FotosDbContext();

        // GET: Shop
        public ActionResult Index()
        {
            var albumList = db.Albums.ToList();
            ViewBag.Albums = albumList;

            return View(albumList);
        }
    }
}