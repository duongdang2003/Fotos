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
    public class PhotosController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Photos
        public ActionResult Index()
        {
            var photos = db.Photos.Include(p => p.Album).Include(p => p.Nguoi_dung);
            return View(photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album");
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_photo,id_nguoi_dung,id_album,tieu_de_anh,mo_ta_anh,url_anh,ngay_tai_anh_len,so_luot_danh_gia,so_luot_thich")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", photo.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", photo.id_nguoi_dung);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", photo.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", photo.id_nguoi_dung);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_photo,id_nguoi_dung,id_album,tieu_de_anh,mo_ta_anh,url_anh,ngay_tai_anh_len,so_luot_danh_gia,so_luot_thich")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", photo.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", photo.id_nguoi_dung);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
