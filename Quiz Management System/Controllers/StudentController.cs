using Microsoft.AspNetCore.Mvc;
using Quiz_Management_System.Data;
using Quiz_Management_System.Models;

namespace Quiz_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashBoard() => View();
        public IActionResult Quiz()
        {
            IEnumerable<Models.Quiz> quizzes = _db.quizzes.ToList();
            return View(quizzes);
        }
        public IActionResult displayQuiz()
        {
            Console.WriteLine("Here");
            return RedirectToAction("QuizInfo");
        }
        public IActionResult Marks()
        {
            return View();
        }
        public IActionResult Course()
        {
            IEnumerable<Models.Course> courses = _db.courses.ToList();
            return View(courses);
        }
        public IActionResult CourseInfo()
        {

            return View();
        }
        public IActionResult QuizInfo()
        {
            return View();
        }
    }
}
