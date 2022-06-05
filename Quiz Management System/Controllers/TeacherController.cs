using Microsoft.AspNetCore.Mvc;
using Quiz_Management_System.Data;
using Quiz_Management_System.Models;

namespace Quiz_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult DashBoard()
        {

            return View();
        }

        public IActionResult displayQuiz()
        {
            Console.WriteLine("Here");
            return RedirectToAction("QuizInfo");
        }
        public IActionResult QuizInfo()
        {
            return View();
        }
        public IActionResult Quiz() {
            IEnumerable<Models.Quiz> quizzes = _db.quizzes.ToList();
            return View(quizzes); 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
