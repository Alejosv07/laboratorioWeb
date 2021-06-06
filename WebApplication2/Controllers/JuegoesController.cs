using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class JuegoesController : Controller
    {
        private WebApplication2Context12 db = new WebApplication2Context12();

        // GET: Juegoes
        public ActionResult Index(int? orderTable)
        {
            //Si el metodo recibe 1 quiere decir que tenemos que ordenar la tabla de percio mayor a menor
            var juegoes = db.Juegoes.Include(j => j.categoria);
            if (orderTable == 1)
            {
                juegoes = db.Juegoes.Include(j => j.categoria).OrderByDescending(j => j.precio);
            }
            return View(juegoes.ToList());
        }

        // GET: Juegoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juegoes.Find(id);
            juego.categoria = db.Categorias.Find(juego.idcategoria);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: Juegoes/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.Categorias, "idcategoria", "Nombrecategoria");
            return View();
        }

        // POST: Juegoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idjuego,nomJuego,idcategoria,precio,existencias,ImageFile")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(juego.ImageFile.FileName);
                string extension = Path.GetExtension(juego.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                juego.imagen = "/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                juego.ImageFile.SaveAs(fileName);
                db.Juegoes.Add(juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.Categorias, "idcategoria", "Nombrecategoria", juego.idcategoria);
            return View(juego);
        }

        // GET: Juegoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juegoes.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.Categorias, "idcategoria", "Nombrecategoria", juego.idcategoria);
            return View(juego);
        }

        // POST: Juegoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idjuego,nomJuego,idcategoria,precio,existencias,ImageFile")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(juego.ImageFile.FileName);
                string extension = Path.GetExtension(juego.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                juego.imagen = "/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                juego.ImageFile.SaveAs(fileName);
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.Categorias, "idcategoria", "Nombrecategoria", juego.idcategoria);
            return View(juego);
        }

        // GET: Juegoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juegoes.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: Juegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juego juego = db.Juegoes.Find(id);
            db.Juegoes.Remove(juego);
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
