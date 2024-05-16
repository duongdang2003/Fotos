<<<<<<< HEAD
﻿using System;
=======
﻿using Fotos.Code;
using Models.Framework;
using System;
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{
<<<<<<< HEAD
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
=======

    public class UserProfileController : Controller
    {

        private FotosDbContext db = new FotosDbContext();

        // GET: UserProfile
        public ActionResult Index()
        {
            var username = SessionHelper.GetSession().username;
            ViewBag.Username = username;

            var albumList = db.Albums.ToList();
            ViewBag.AlbumList = albumList;

            return View(db.Nguoi_dung.ToList());
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
        }
    }
}