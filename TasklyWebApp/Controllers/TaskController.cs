using Microsoft.AspNetCore.Mvc;
using TasklyWebApp.Data;
using TasklyWebApp.Models;


namespace TasklyWebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Models.ToDo> objTaskList = _db.ToDos;
            return View(objTaskList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _ = _db.ToDos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.ToDos.Find(id);
            //var taskFromDb = _db.Tasks.FirstOrDefault( c=>c.TaskId == id);

            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.ToDos.Find(id);
            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.ToDos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
