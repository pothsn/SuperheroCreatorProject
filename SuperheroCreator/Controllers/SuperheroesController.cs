using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext context;
        public SuperheroesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Superheroes
        public ActionResult Index()
        {
            List<Superhero> superheroList = context.Superheroes.ToList();
            return View(superheroList);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = context.Superheroes.Where(i => i.Id == id).Single();
            return View(superhero);
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            //Superhero superhero = context.Superheroes.Where(i => i.Id == id).FirstOrDefault();
            Superhero superhero = context.Superheroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        [HttpPost]
        public ActionResult Edit(Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                context.Entry(superhero).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int? id)
        {
            Superhero superhero = context.Superheroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // POST: Superheroes/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Superhero superhero = context.Superheroes.Find(id);
            context.Superheroes.Remove(superhero);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
