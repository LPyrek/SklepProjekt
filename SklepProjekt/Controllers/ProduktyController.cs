using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SklepProjekt.Models;
using Sklep.Controllers;
public class ProduktyController : Controller
{
    private SklepContext db = new SklepContext();

    // GET: Produkty
    public ActionResult Index()
    {
        var produkty = db.Produkty.ToList();
        return View(produkty);
    }

    // GET: Produkty/Details/
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Produkt produkt = db.Produkty.Find(id);
        if (produkt == null)
        {
            return HttpNotFound();
        }
        return View(produkt);
    }

    // GET: Produkty/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Produkty/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Produkt produkt)
    {
        if (ModelState.IsValid)
        {
            db.Produkty.Add(produkt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(produkt);
    }


    // GET: Produkty/Edit/
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Produkt produkt = db.Produkty.Find(id);
        if (produkt == null)
        {
            return HttpNotFound();
        }
        return View(produkt);
    }

    // POST: Produkty/Edit/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Produkt produkt)
    {
        if (ModelState.IsValid)
        {
            db.Entry(produkt).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(produkt);
    }



    // GET: Produkty/Delete/
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Produkt produkt = db.Produkty.Find(id);
        if (produkt == null)
        {
            return HttpNotFound();
        }
        return View(produkt);
    }

    // POST: Produkty/Delete/
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Produkt produkt = db.Produkty.Find(id);
        db.Produkty.Remove(produkt);
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
