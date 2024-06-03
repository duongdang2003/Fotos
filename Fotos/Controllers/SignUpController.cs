using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fotos.Controllers
{

    public class SignUpController : Controller
    {
        private FotosDbContext db = new FotosDbContext();
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nguoi_dung,ten_nguoi_dung,email,mat_khau_hashed,salt,ten_day_du,so_dien_thoai,ngay_dang_ky")] Nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                db.Nguoi_dung.Add(nguoi_dung);
                db.SaveChanges();
                return RedirectToAction("Index", "SignIn");
            }

            return View(nguoi_dung);
        }
    }
}