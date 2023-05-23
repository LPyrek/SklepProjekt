using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SklepProjekt.Models;

public class ZamowieniaController : Controller
{
    private SklepContext db = new SklepContext();

    // GET: Zamowienia
    public ActionResult Index()
    {
        var zamowienia = db.Zamowienia.ToList();
        return View(zamowienia);
    }

    // GET: Zamowienia/Details/
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Zamowienie zamowienie = db.Zamowienia.Find(id);
        if (zamowienie == null)
        {
            return HttpNotFound();
        }
        return View(zamowienie);
    }

    // GET: Zamowienia/Create
    public ActionResult Create()
    {
        ViewBag.ID_klienta = db.Klienci
            .Select(k => new SelectListItem
            {
                Value = k.ID_klienta.ToString(),
                Text = "(" + k.ID_klienta + ")" + " - " + k.Imie + " " + k.Nazwisko
            })
            .ToList();

        ViewBag.ID_produktu = new SelectList(db.Produkty, "ID_produktu", "Nazwa_produktu");

        return View();
    }

    // POST: Zamowienia/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Zamowienie zamowienie)
    {
        if (ModelState.IsValid)
        {
            db.Zamowienia.Add(zamowienie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.ID_klienta = db.Klienci.Select(k => new SelectListItem
        {
            Value = k.ID_klienta.ToString(),
            Text = "(" + k.ID_klienta + ")" + " - " + k.Imie + " " + k.Nazwisko
        }).ToList();
        ViewBag.ID_produktu = new SelectList(db.Produkty, "ID_produktu", "Nazwa_produktu");
        return View(zamowienie);
    }

    // GET: Zamowienia/Edit/
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var zamowienie = db.Zamowienia.Find(id);
        if (zamowienie == null)
        {
            return HttpNotFound();
        }

        ViewBag.ID_klienta = db.Klienci.Select(k => new SelectListItem
        {
            Value = k.ID_klienta.ToString(),
            Text = "(" + k.ID_klienta + ")" + " - " + k.Imie + " " + k.Nazwisko
        }).ToList();
        var produkty = db.Produkty.ToList();
        ViewBag.ID_produktu = new SelectList(produkty, "ID_produktu", "Nazwa_produktu", zamowienie.ID_produktu);
        return View(zamowienie);
    }

    // POST: Zamowienia/Edit/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Zamowienie zamowienie)
    {
        if (ModelState.IsValid)
        {
            var existingZamowienie = db.Zamowienia.Find(zamowienie.ID_Zamowienia); // Znajdź istniejące zamówienie w bazie danych
            if (existingZamowienie != null)
            {
                db.Entry(existingZamowienie).CurrentValues.SetValues(zamowienie); // Zaktualizuj wartości istniejącego zamówienia z wartościami z edytowanego zamówienia

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    db.Entry(existingZamowienie).Reload(); // Odśwież zamówienie z bazą danych
                    db.SaveChanges(); // Zapisz ponownie
                }
                return RedirectToAction("Index");
            }
        }
        ViewBag.ID_klienta = db.Klienci.Select(k => new SelectListItem
        {
            Value = k.ID_klienta.ToString(),
            Text = "(" + k.ID_klienta + ")" + " - " + k.Imie + " " + k.Nazwisko
        }).ToList();
        var produkty = db.Produkty.ToList();
        ViewBag.ID_produktu = new SelectList(produkty, "ID_produktu", "Nazwa_produktu", zamowienie.ID_produktu);
        return View(zamowienie);
    }

    // GET: Zamowienia/Delete/
    public ActionResult Delete(int id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var zamowienie = db.Zamowienia.Find(id);
        if (zamowienie == null)
        {
            return HttpNotFound();
        }

        return View(zamowienie);
    }

    // POST: Zamowienia/Delete/
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var zamowienie = db.Zamowienia.Find(id);
        if (zamowienie == null)
        {
            return HttpNotFound();
        }

        db.Zamowienia.Remove(zamowienie);
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

