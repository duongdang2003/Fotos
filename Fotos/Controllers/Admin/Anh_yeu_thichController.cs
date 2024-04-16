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
    public class Anh_yeu_thichController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Anh_yeu_thich
        public ActionResult Index()
        {
            var anh_yeu_thich = db.Anh_yeu_thich.Include(a => a.Nguoi_dung).Include(a => a.Photo);
            return View(anh_yeu_thich.ToList());
        }

        // GET: Anh_yeu_thich/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh_yeu_thich anh_yeu_thich = db.Anh_yeu_thich.Find(id);
            if (anh_yeu_thich == null)
            {
                return HttpNotFound();
            }
            return View(anh_yeu_thich);
        }

        // GET: Anh_yeu_thich/Create
        public ActionResult Create()
        {
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh");
            return View();
        }

        // POST: Anh_yeu_thich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_anh_yeu_thich,id_nguoi_dung,id_anh,ngay_yeu_thich")] Anh_yeu_thich anh_yeu_thich)
        {
            if (ModelState.IsValid)
            {
                db.Anh_yeu_thich.Add(anh_yeu_thich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", anh_yeu_thich.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", anh_yeu_thich.id_anh);
            return View(anh_yeu_thich);
        }

        // GET: Anh_yeu_thich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh_yeu_thich anh_yeu_thich = db.Anh_yeu_thich.Find(id);
            if (anh_yeu_thich == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", anh_yeu_thich.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", anh_yeu_thich.id_anh);
            return View(anh_yeu_thich);
        }

        // POST: Anh_yeu_thich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_anh_yeu_thich,id_nguoi_dung,id_anh,ngay_yeu_thich")] Anh_yeu_thich anh_yeu_thich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anh_yeu_thich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", anh_yeu_thich.id_nguoi_dung);
            ViewBag.id_anh = new SelectList(db.Photos, "id_photo", "tieu_de_anh", anh_yeu_thich.id_anh);
            return View(anh_yeu_thich);
        }

        // GET: Anh_yeu_thich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh_yeu_thich anh_yeu_thich = db.Anh_yeu_thich.Find(id);
            if (anh_yeu_thich == null)
            {
                return HttpNotFound();
            }
            return View(anh_yeu_thich);
        }

        // POST: Anh_yeu_thich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anh_yeu_thich anh_yeu_thich = db.Anh_yeu_thich.Find(id);
            db.Anh_yeu_thich.Remove(anh_yeu_thich);
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
