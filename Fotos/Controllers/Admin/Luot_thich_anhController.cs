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
    public class Luot_thich_anhController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Luot_thich_anh
        public ActionResult Index()
        {
            var luot_thich_anh = db.Luot_thich_anh.Include(l => l.Nguoi_dung).Include(l => l.Photo);
            return View(luot_thich_anh.ToList());
        }

        // GET: Luot_thich_anh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_anh luot_thich_anh = db.Luot_thich_anh.Find(id);
            if (luot_thich_anh == null)
            {
                return HttpNotFound();
            }
            return View(luot_thich_anh);
        }

        // GET: Luot_thich_anh/Create
        public ActionResult Create()
        {
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh");
            return View();
        }

        // POST: Luot_thich_anh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_luot_thich,id_nguoi_dung,id_anh,ngay_thich")] Luot_thich_anh luot_thich_anh)
        {
            if (ModelState.IsValid)
            {
                db.Luot_thich_anh.Add(luot_thich_anh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", luot_thich_anh.id_anh);
            return View(luot_thich_anh);
        }

        // GET: Luot_thich_anh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_anh luot_thich_anh = db.Luot_thich_anh.Find(id);
            if (luot_thich_anh == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", luot_thich_anh.id_anh);
            return View(luot_thich_anh);
        }

        // POST: Luot_thich_anh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_luot_thich,id_nguoi_dung,id_anh,ngay_thich")] Luot_thich_anh luot_thich_anh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luot_thich_anh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", luot_thich_anh.id_anh);
            return View(luot_thich_anh);
        }

        // GET: Luot_thich_anh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_anh luot_thich_anh = db.Luot_thich_anh.Find(id);
            if (luot_thich_anh == null)
            {
                return HttpNotFound();
            }
            return View(luot_thich_anh);
        }

        // POST: Luot_thich_anh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luot_thich_anh luot_thich_anh = db.Luot_thich_anh.Find(id);
            db.Luot_thich_anh.Remove(luot_thich_anh);
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
    }
}
