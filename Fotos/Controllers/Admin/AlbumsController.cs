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
    public class AlbumsController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Nguoi_dung);
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_album,so_luong_anh,id_nguoi_dung,tieu_de_album,mo_ta_album,ngay_tao_album,so_luot_danh_gia,so_luot_thich")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", album.id_nguoi_dung);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", album.id_nguoi_dung);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_album,so_luong_anh,id_nguoi_dung,tieu_de_album,mo_ta_album,ngay_tao_album,so_luot_danh_gia,so_luot_thich")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_nguoi_dung = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", album.id_nguoi_dung);
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
        public ActionResult CreateAlbum(Album album)
        {
            if (album == null)
            {
                return Content("No album");
            }
            System.Diagnostics.Debug.WriteLine(album);
            if (ModelState.IsValid)
            {
                try
                {
                    album.tieu_de_album = album.tieu_de_album;
                    album.mo_ta_album = album.mo_ta_album;
                    album.so_luot_thich = 0;
                    album.so_luot_danh_gia = 0;
                    album.ngay_tao_album = DateTime.Now;
                    album.id_nguoi_dung = album.id_nguoi_dung;
                    db.Albums.Add(album);
                    db.SaveChanges();
                    return Content(album.id_album.ToString());
                }
                catch (Exception ex)
                {
                    var innerExceptionMessage = ex.InnerException?.InnerException?.Message ?? ex.Message;
                    return Content(innerExceptionMessage);
                }
            }
            return Content("Cannot create");
        }
        [HttpPost]
        public ActionResult GetAlbumsByUserId(int idNguoiDung)
        {
            var albums = db.Albums.Where(a => a.id_nguoi_dung == idNguoiDung).ToList();

            if (albums == null || albums.Count == 0)
            {
                return HttpNotFound();
            }

            return Json(albums, JsonRequestBehavior.AllowGet);
        }
    }
}
