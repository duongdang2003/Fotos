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
    public class Luot_thich_albumController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Luot_thich_album
        public ActionResult Index()
        {
            var luot_thich_album = db.Luot_thich_album.Include(l => l.Album).Include(l => l.Nguoi_dung);
            return View(luot_thich_album.ToList());
        }

        // GET: Luot_thich_album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_album luot_thich_album = db.Luot_thich_album.Find(id);
            if (luot_thich_album == null)
            {
                return HttpNotFound();
            }
            return View(luot_thich_album);
        }

        // GET: Luot_thich_album/Create
        public ActionResult Create()
        {
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album");
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            return View();
        }

        // POST: Luot_thich_album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_luot_thich,id_nguoi_dung,id_album,ngay_thich")] Luot_thich_album luot_thich_album)
        {
            if (ModelState.IsValid)
            {
                db.Luot_thich_album.Add(luot_thich_album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", luot_thich_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_album.id_nguoi_dung);
            return View(luot_thich_album);
        }

        // GET: Luot_thich_album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_album luot_thich_album = db.Luot_thich_album.Find(id);
            if (luot_thich_album == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", luot_thich_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_album.id_nguoi_dung);
            return View(luot_thich_album);
        }

        // POST: Luot_thich_album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_luot_thich,id_nguoi_dung,id_album,ngay_thich")] Luot_thich_album luot_thich_album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luot_thich_album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", luot_thich_album.id_album);
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", luot_thich_album.id_nguoi_dung);
            return View(luot_thich_album);
        }

        // GET: Luot_thich_album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luot_thich_album luot_thich_album = db.Luot_thich_album.Find(id);
            if (luot_thich_album == null)
            {
                return HttpNotFound();
            }
            return View(luot_thich_album);
        }

        // POST: Luot_thich_album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luot_thich_album luot_thich_album = db.Luot_thich_album.Find(id);
            db.Luot_thich_album.Remove(luot_thich_album);
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
