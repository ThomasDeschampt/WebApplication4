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
    public class JoueursController : Controller
    {
        private NBAEntities db = new NBAEntities();

        // GET: Joueurs
        public async Task<ActionResult> Index()
        {
            var joueurs = db.Joueurs.Include(j => j.Equipes);
            return View(await joueurs.ToListAsync());
        }

        // GET: Joueurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueurs joueurs = await db.Joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            return View(joueurs);
        }

        // GET: Joueurs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Equipe = new SelectList(db.Equipes, "ID_Equipe", "NOM_Equipe");
            return View();
        }

        // POST: Joueurs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Joueur,NOM_Joueur,PRENOM_Joueur,AGE_Joueur,NUMERO_Joueur,POSTE_Joueur,ID_Equipe")] Joueurs joueurs)
        {
            if (ModelState.IsValid)
            {
                db.Joueurs.Add(joueurs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Equipe = new SelectList(db.Equipes, "ID_Equipe", "NOM_Equipe", joueurs.ID_Equipe);
            return View(joueurs);
        }

        // GET: Joueurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueurs joueurs = await db.Joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Equipe = new SelectList(db.Equipes, "ID_Equipe", "NOM_Equipe", joueurs.ID_Equipe);
            return View(joueurs);
        }

        // POST: Joueurs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Joueur,NOM_Joueur,PRENOM_Joueur,AGE_Joueur,NUMERO_Joueur,POSTE_Joueur,ID_Equipe")] Joueurs joueurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joueurs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Equipe = new SelectList(db.Equipes, "ID_Equipe", "NOM_Equipe", joueurs.ID_Equipe);
            return View(joueurs);
        }

        // GET: Joueurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueurs joueurs = await db.Joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            return View(joueurs);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Joueurs joueurs = await db.Joueurs.FindAsync(id);
            db.Joueurs.Remove(joueurs);
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
