using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EquipesController : Controller
    {
        private NBAEntities db = new NBAEntities();

        // GET: Equipes
        public async Task<ActionResult> Index()
        {
            return View(await db.Equipes.ToListAsync());
        }

        // GET: Equipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipes equipes = await db.Equipes.FindAsync(id);
            if (equipes == null)
            {
                return HttpNotFound();
            }
            return View(equipes);
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Equipe,NOM_Equipe,LIB_Equipe,NOMBRE_VICTOIRES_Equipe,NOMBRE_DEFAITES_Equipe,CONFERENCE_Equipe")] Equipes equipes)
        {
            if (ModelState.IsValid)
            {
                db.Equipes.Add(equipes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equipes);
        }

        // GET: Equipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipes equipes = await db.Equipes.FindAsync(id);
            if (equipes == null)
            {
                return HttpNotFound();
            }
            return View(equipes);
        }

        // POST: Equipes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Equipe,NOM_Equipe,LIB_Equipe,NOMBRE_VICTOIRES_Equipe,NOMBRE_DEFAITES_Equipe,CONFERENCE_Equipe")] Equipes equipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equipes);
        }

        // GET: Equipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipes equipes = await db.Equipes.FindAsync(id);
            if (equipes == null)
            {
                return HttpNotFound();
            }
            return View(equipes);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Equipes equipes = await db.Equipes.FindAsync(id);
            db.Equipes.Remove(equipes);
            await db.SaveChangesAsync();
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
