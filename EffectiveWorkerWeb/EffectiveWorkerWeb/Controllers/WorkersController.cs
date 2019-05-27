using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationContext _db;
        
        public WorkersController(ApplicationContext db) {
            _db = db;
        }
        
        public IActionResult Show() {
         var workers = _db.Workers.Include(w => w.Projects);
            return View(workers);
        }   
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(Worker worker) {
            _db.Add(worker);
            _db.SaveChanges();
            return Redirect("/workers");
        }
        
        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null) return NotFound();
            var worker = _db.Workers.Find(id);
            if (worker != null) return View(worker);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Worker worker) {
            _db.Entry(worker).State = EntityState.Modified;
            _db.SaveChanges();
            return Redirect("/workers/show");
        }
        
        [HttpGet]
        public ActionResult Delete(int? id) {
            if (id == null) return NotFound();
            var worker = _db.Workers.Find(id);
            if (worker == null) return NotFound();
            return View(worker);
        }
        
        [HttpPost, ActionName("delete")]
        public ActionResult DeleteConfirmed(int id) {
            var worker = _db.Workers.Find(id);
            if (worker == null) return NotFound();
            _db.Entry(worker).State = EntityState.Deleted;
            _db.SaveChanges();
            return Redirect("/workers");
        }
    }
}