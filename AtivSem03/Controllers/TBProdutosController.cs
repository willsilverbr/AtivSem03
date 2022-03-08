using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtivSem03.Models;

namespace AtivSem03.Controllers
{
    public class TBProdutosController : Controller
    {
        private ComprasClienteEntities db = new ComprasClienteEntities();

        // GET: TBProdutos
        public ActionResult Index()
        {
            return View(db.TBProdutos.ToList());
        }

        // GET: TBProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProdutos tBProdutos = db.TBProdutos.Find(id);
            if (tBProdutos == null)
            {
                return HttpNotFound();
            }
            return View(tBProdutos);
        }

        // GET: TBProdutos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeProduto,quantidade,Valor")] TBProdutos tBProdutos)
        {
            if (ModelState.IsValid)
            {
                db.TBProdutos.Add(tBProdutos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBProdutos);
        }

        // GET: TBProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProdutos tBProdutos = db.TBProdutos.Find(id);
            if (tBProdutos == null)
            {
                return HttpNotFound();
            }
            return View(tBProdutos);
        }

        // POST: TBProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeProduto,quantidade,Valor")] TBProdutos tBProdutos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBProdutos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBProdutos);
        }

        // GET: TBProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBProdutos tBProdutos = db.TBProdutos.Find(id);
            if (tBProdutos == null)
            {
                return HttpNotFound();
            }
            return View(tBProdutos);
        }

        // POST: TBProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBProdutos tBProdutos = db.TBProdutos.Find(id);
            db.TBProdutos.Remove(tBProdutos);
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
