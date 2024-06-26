﻿using Fotos.Code;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{

    public class UserProfileController : Controller
    {

        private FotosDbContext db = new FotosDbContext();
        private String userName = "";
        // GET: UserProfile
        public ActionResult Index()
        {
            var username = SessionHelper.GetSession().username;
            userName = SessionHelper.GetSession().username; 
            ViewBag.Username = username;

            var albumList = db.Albums.ToList();
            ViewBag.AlbumList = albumList;

            return View(db.Nguoi_dung.ToList());
        }
        public ActionResult SaveImagePath()
        {
            return Content("call success");
        }

        [HttpGet]
        public ActionResult GetUserName()
        {
            return Content(userName);
        }
    }
}