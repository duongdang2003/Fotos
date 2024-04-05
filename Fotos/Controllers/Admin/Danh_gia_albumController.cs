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
    public class Danh_gia_albumController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Danh_gia_album
        public ActionResult Index()
        {
            var danh_gia_album = db.Danh_gia_album.Include(d => d.Album).Include(d => d.Nguoi_dung);
            return View(danh_gia_album.ToList());
        }

        // GET: Danh_gia_album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_album danh_gia_album = db.Danh_gia_album.Find(id);
            if (danh_gia_album == null)
            {
                return HttpNotFound();
            }
            return View(danh_gia_album);
        }

        // GET: Danh_gia_album/Create
        public ActionResult Create()
        {
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album");
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            return View();
        }

        // POST: Danh_gia_album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_danh_gia,id_nguoi_dung,id_album,binh_luan,ngay_binh_luan")] Danh_gia_album danh_gia_album)
        {
            if (ModelState.IsValid)
            {
                db.Danh_gia_album.Add(danh_gia_album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", danh_gia_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_album.id_nguoi_dung);
            return View(danh_gia_album);
        }

        // GET: Danh_gia_album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_album danh_gia_album = db.Danh_gia_album.Find(id);
            if (danh_gia_album == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", danh_gia_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_album.id_nguoi_dung);
            return View(danh_gia_album);
        }

        // POST: Danh_gia_album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_danh_gia,id_nguoi_dung,id_album,binh_luan,ngay_binh_luan")] Danh_gia_album danh_gia_album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_gia_album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", danh_gia_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", danh_gia_album.id_nguoi_dung);
            return View(danh_gia_album);
        }

        // GET: Danh_gia_album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_gia_album danh_gia_album = db.Danh_gia_album.Find(id);
            if (danh_gia_album == null)
            {
                return HttpNotFound();
            }
            return View(danh_gia_album);
        }

        // POST: Danh_gia_album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Danh_gia_album danh_gia_album = db.Danh_gia_album.Find(id);
            db.Danh_gia_album.Remove(danh_gia_album);
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
