using Microsoft.AspNetCore.Mvc;
using Assignment_5;

namespace Assign_5Pro.Controllers
{
    public class TasskController : Controller
    {

        private readonly TaskssDbContext _context;

        public TasskController()
        {
            _context = new TaskssDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index()
        {
            return View();
        }

        //Tassk/Add
        public ActionResult Add()
        {
            return View("AddTask");
        }


        [HttpPost]
        public IActionResult CreateTask([FromBody] Assignment_5.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok();
            //return RedirectToAction("GetTask" , "Tassk");

        }

        ///Tassk/GetTask
        [HttpGet]
        [Route("GetTask")]
        public IActionResult GetTask()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
            //return View("Tassk",tasks);
        }

        //[HttpPost("AddTask")]
        [HttpPost]
        public IActionResult AddTask([FromBody] Assignment_5.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok();
            //return RedirectToAction("GetTask" , "Tassk");
            
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteTask(int id)
        {
            Assignment_5.Task p = _context.Tasks.Find(id);
           _context.Tasks.Remove(p);
            _context.SaveChanges();
            return Ok();
        }
    }
}
