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
    public class Danh_gia_anhController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Danh_gia_anh
        public ActionResult Index()
        {
            var danh_gia_anh = db.Danh_gia_anh.Include(d => d.Nguoi_dung).Include(d => d.Photo);
            return View(danh_gia_anh.ToList());
        }

        // GET: Danh_gia_anh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_anh danh_gia_anh = db.Danh_gia_anh.Find(id);
            if (danh_gia_anh == null)
            {
                return HttpNotFound();
            }
            return View(danh_gia_anh);
        }

        // GET: Danh_gia_anh/Create
        public ActionResult Create()
        {
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh");
            return View();
        }

        // POST: Danh_gia_anh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_danh_gia,id_nguoi_dung,id_anh,binh_luan,ngay_binh_luan")] Danh_gia_anh danh_gia_anh)
        {
            if (ModelState.IsValid)
            {
                db.Danh_gia_anh.Add(danh_gia_anh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", danh_gia_anh.id_anh);
            return View(danh_gia_anh);
        }

        // GET: Danh_gia_anh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_anh danh_gia_anh = db.Danh_gia_anh.Find(id);
            if (danh_gia_anh == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", danh_gia_anh.id_anh);
            return View(danh_gia_anh);
        }

        // POST: Danh_gia_anh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_danh_gia,id_nguoi_dung,id_anh,binh_luan,ngay_binh_luan")] Danh_gia_anh danh_gia_anh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_gia_anh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_anh.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", danh_gia_anh.id_anh);
            return View(danh_gia_anh);
        }

        // GET: Danh_gia_anh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_anh danh_gia_anh = db.Danh_gia_anh.Find(id);
            if (danh_gia_anh == null)
            {
                return HttpNotFound();
            }
            return View(danh_gia_anh);
        }

        // POST: Danh_gia_anh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Danh_gia_anh danh_gia_anh = db.Danh_gia_anh.Find(id);
            db.Danh_gia_anh.Remove(danh_gia_anh);
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
