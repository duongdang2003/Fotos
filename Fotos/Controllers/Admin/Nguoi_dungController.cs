using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace Fotos.Controllers.Admin
{
    public class Nguoi_dungController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Nguoi_dung
        public ActionResult Index()
        {
            return View(db.Nguoi_dung.ToList());
        }

        // GET: Nguoi_dung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_dung nguoi_dung = db.Nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // GET: Nguoi_dung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nguoi_dung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_nguoi_dung,ten_nguoi_dung,email,mat_khau_hashed,salt,ten_day_du,so_dien_thoai,ngay_dang_ky")] Nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                db.Nguoi_dung.Add(nguoi_dung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoi_dung);
        }

        // GET: Nguoi_dung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_dung nguoi_dung = db.Nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // POST: Nguoi_dung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nguoi_dung,ten_nguoi_dung,email,mat_khau_hashed,salt,ten_day_du,so_dien_thoai,ngay_dang_ky")] Nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoi_dung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoi_dung);
        }

        // GET: Nguoi_dung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_dung nguoi_dung = db.Nguoi_dung.Find(id);
            if (nguoi_dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_dung);
        }

        // POST: Nguoi_dung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nguoi_dung nguoi_dung = db.Nguoi_dung.Find(id);
            db.Nguoi_dung.Remove(nguoi_dung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return Json(new { success = false, message = "Username require" }, JsonRequestBehavior.AllowGet);
            }

            Nguoi_dung nguoi_dung = db.Nguoi_dung.FirstOrDefault(u => u.ten_nguoi_dung == username);
            if (nguoi_dung == null)
            {
                return Json(new { success = false, message = "User not found" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, data = nguoi_dung }, JsonRequestBehavior.AllowGet);
        }
    }

}
