using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationContext _db;
        
        public ProjectsController(ApplicationContext db) {
            _db = db;
        }
        
        public ActionResult Show() {
            return View(_db.Projects.Include(p => p.Worker).ToList());
        }
        
        [HttpGet]
        public ActionResult Add() {
            var workersData = _db.Workers.Include(w => w.Projects).ToList();
            var workers = new SelectList(workersData, "Id", "Surname");
            ViewBag.Workers = workers;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Project project) {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return Redirect("/projects/show");
        }
        
        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null) return NotFound();
            var project = _db.Projects.Find(id);
            if (project != null) return View(project);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Project project) {
            _db.Entry(project).State = EntityState.Modified;
            _db.SaveChanges();
            return Redirect("/projects/show");
        }
        
        [HttpGet]
        public ActionResult Delete(int? id) {
            if (id == null) return NotFound();
            var project = _db.Projects.Find(id);
            if (project == null) return NotFound();
            return View(project);
        }

        [HttpPost, ActionName("delete")]
        public ActionResult DeleteConfirmed(int id) {
            var project = _db.Projects.Find(id);
            if (project == null) return NotFound();
            _db.Entry(project).State = EntityState.Deleted;
            _db.SaveChanges();
            return Redirect("/projects/show");
        }
    }
}