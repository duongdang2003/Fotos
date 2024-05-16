<<<<<<< HEAD
﻿using System;
=======
﻿using Models.Framework;
using System;
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
    public class ShopController : Controller
    {
<<<<<<< HEAD
        // GET: Shop
        public ActionResult Index()
        {
            return View();
=======

        private FotosDbContext db = new FotosDbContext();

        // GET: Shop
        public ActionResult Index()
        {
            var albumList = db.Albums.ToList();
            ViewBag.Albums = albumList;

            return View(albumList);
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
        }
    }
}