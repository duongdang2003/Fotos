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
    public class Giao_dichController : Controller
    {
        private FotosDbContext db = new FotosDbContext();

        // GET: Giao_dich
        public ActionResult Index()
        {
            var giao_dich = db.Giao_dich.Include(g => g.Album).Include(g => g.Nguoi_dung).Include(g => g.Nguoi_dung1);
            return View(giao_dich.ToList());
        }

        // GET: Giao_dich/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giao_dich giao_dich = db.Giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            return View(giao_dich);
        }

        // GET: Giao_dich/Create
        public ActionResult Create()
        {
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album");
            ViewBag.id_nguoi_ban = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            ViewBag.id_nguoi_mua = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung");
            return View();
        }

        // POST: Giao_dich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_giao_dich,id_nguoi_mua,id_nguoi_ban,id_album,gia_tien,ngay_giao_dich")] Giao_dich giao_dich)
        {
            if (ModelState.IsValid)
            {
                db.Giao_dich.Add(giao_dich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", giao_dich.id_album);
            ViewBag.id_nguoi_ban = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_ban);
            ViewBag.id_nguoi_mua = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_mua);
            return View(giao_dich);
        }

        // GET: Giao_dich/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giao_dich giao_dich = db.Giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", giao_dich.id_album);
            ViewBag.id_nguoi_ban = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_ban);
            ViewBag.id_nguoi_mua = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_mua);
            return View(giao_dich);
        }

        // POST: Giao_dich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_giao_dich,id_nguoi_mua,id_nguoi_ban,id_album,gia_tien,ngay_giao_dich")] Giao_dich giao_dich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giao_dich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_album = new SelectList(db.Albums, "id_album", "tieu_de_album", giao_dich.id_album);
            ViewBag.id_nguoi_ban = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_ban);
            ViewBag.id_nguoi_mua = new SelectList(db.Nguoi_dung, "id_nguoi_dung", "ten_nguoi_dung", giao_dich.id_nguoi_mua);
            return View(giao_dich);
        }

        // GET: Giao_dich/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giao_dich giao_dich = db.Giao_dich.Find(id);
            if (giao_dich == null)
            {
                return HttpNotFound();
            }
            return View(giao_dich);
        }

        // POST: Giao_dich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giao_dich giao_dich = db.Giao_dich.Find(id);
            db.Giao_dich.Remove(giao_dich);
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
