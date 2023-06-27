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
    public class MatchsController : Controller
    {
        private NBAEntities db = new NBAEntities();

        // GET: Matchs
        public async Task<ActionResult> Index()
        {
            return View(await db.Matchs.ToListAsync());
        }

        // GET: Matchs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matchs matchs = await db.Matchs.FindAsync(id);
            if (matchs == null)
            {
                return HttpNotFound();
            }
            return View(matchs);
        }

        // GET: Matchs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matchs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Match,LIEU_Match,DATE_Match,ID_EQUIPE_VIS_Match,ID_EQUIPE_DOM_Match,SCORE_VIS_Match,SCORE_DOM_Match")] Matchs matchs)
        {
            if (ModelState.IsValid)
            {
                db.Matchs.Add(matchs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(matchs);
        }

        // GET: Matchs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matchs matchs = await db.Matchs.FindAsync(id);
            if (matchs == null)
            {
                return HttpNotFound();
            }
            return View(matchs);
        }

        // POST: Matchs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Match,LIEU_Match,DATE_Match,ID_EQUIPE_VIS_Match,ID_EQUIPE_DOM_Match,SCORE_VIS_Match,SCORE_DOM_Match")] Matchs matchs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(matchs);
        }

        // GET: Matchs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matchs matchs = await db.Matchs.FindAsync(id);
            if (matchs == null)
            {
                return HttpNotFound();
            }
            return View(matchs);
        }

        // POST: Matchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Matchs matchs = await db.Matchs.FindAsync(id);
            db.Matchs.Remove(matchs);
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
