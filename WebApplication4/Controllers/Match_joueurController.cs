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
    public class Match_joueurController : Controller
    {
        private NBAEntities db = new NBAEntities();

        // GET: Match_joueur
        public async Task<ActionResult> Index()
        {
            var match_joueur = db.Match_joueur.Include(m => m.Joueurs).Include(m => m.Matchs);
            return View(await match_joueur.ToListAsync());
        }

        // GET: Match_joueur/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match_joueur match_joueur = await db.Match_joueur.FindAsync(id);
            if (match_joueur == null)
            {
                return HttpNotFound();
            }
            return View(match_joueur);
        }

        // GET: Match_joueur/Create
        public ActionResult Create()
        {
            ViewBag.ID_Joueur = new SelectList(db.Joueurs, "ID_Joueur", "NOM_Joueur");
            ViewBag.ID_Match = new SelectList(db.Matchs, "ID_Match", "LIEU_Match");
            return View();
        }

        // POST: Match_joueur/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Match,ID_Joueur,ScoreJoueur")] Match_joueur match_joueur)
        {
            if (ModelState.IsValid)
            {
                db.Match_joueur.Add(match_joueur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Joueur = new SelectList(db.Joueurs, "ID_Joueur", "NOM_Joueur", match_joueur.ID_Joueur);
            ViewBag.ID_Match = new SelectList(db.Matchs, "ID_Match", "LIEU_Match", match_joueur.ID_Match);
            return View(match_joueur);
        }

        // GET: Match_joueur/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match_joueur match_joueur = await db.Match_joueur.FindAsync(id);
            if (match_joueur == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Joueur = new SelectList(db.Joueurs, "ID_Joueur", "NOM_Joueur", match_joueur.ID_Joueur);
            ViewBag.ID_Match = new SelectList(db.Matchs, "ID_Match", "LIEU_Match", match_joueur.ID_Match);
            return View(match_joueur);
        }

        // POST: Match_joueur/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Match,ID_Joueur,ScoreJoueur")] Match_joueur match_joueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match_joueur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Joueur = new SelectList(db.Joueurs, "ID_Joueur", "NOM_Joueur", match_joueur.ID_Joueur);
            ViewBag.ID_Match = new SelectList(db.Matchs, "ID_Match", "LIEU_Match", match_joueur.ID_Match);
            return View(match_joueur);
        }

        // GET: Match_joueur/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match_joueur match_joueur = await db.Match_joueur.FindAsync(id);
            if (match_joueur == null)
            {
                return HttpNotFound();
            }
            return View(match_joueur);
        }

        // POST: Match_joueur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Match_joueur match_joueur = await db.Match_joueur.FindAsync(id);
            db.Match_joueur.Remove(match_joueur);
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
