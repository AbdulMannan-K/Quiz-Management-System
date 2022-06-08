using Microsoft.AspNetCore.Mvc;
using Quiz_Management_System.Data;
using Quiz_Management_System.Models;

namespace Quiz_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public int iddd;
        public Student studenttt;
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
            if (HttpContext.Session.GetString("Id") != null)
            {
                iddd = int.Parse(HttpContext.Session.GetString("Id"));
                IEnumerable<Models.Quiz> quizzes = _db.quizzes.ToList();
                IEnumerable<Models.Student> students = _db.students.ToList();
                IEnumerable<Models.Course> courses = _db.courses.ToList();
                IEnumerable<CourseStudent> courseS = _db.courseStudents.ToList();

                List<Quiz> quizes1 = new List<Quiz>();
                foreach (Models.Quiz quiz in quizzes)
                {
                    foreach (CourseStudent course in courseS)
                    {
                        foreach (Student student in students)
                        {
                            if (quiz.courseId == course.Id && course.StudentId == int.Parse(HttpContext.Session.GetString("Id")))
                            {
                                quizes1.Add(quiz);
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(quizes1.Count);
                return View(quizes1);
            }
            else
            {
                return RedirectToAction("login", "LoginSignup");
            }
            
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
            IEnumerable<Models.Student> students = _db.students.ToList();
            IEnumerable<CourseStudent> courseS = _db.courseStudents.ToList();

            List<CourseStudent> courses1 = new List<CourseStudent>();
            List<Course> courses2 = new List<Course>();

            if (HttpContext.Session.GetString("Id") != null)
            {

                foreach (Models.CourseStudent course in courseS)
                {
                    foreach (Student student in students)
                    {
                        if (course.StudentId == int.Parse(HttpContext.Session.GetString("Id")))
                        {

                            courses1.Add(course);
                            break;
                        }
                    }
                }

                foreach (CourseStudent cs in courses1)
                {
                    foreach (Course c in courses)
                        if (cs.CourseId == c.Id) courses2.Add(c);
                }

                return View(courses2);
            }
            else
            {
                return RedirectToAction("login", "LoginSignup");
            }
        }
        [HttpPost]
        public IActionResult Course(IFormCollection form)
        {


            IEnumerable<Models.Course> courses = _db.courses.ToList();
            IEnumerable<Models.Student> students = _db.students.ToList();
            IEnumerable<CourseStudent> courseS = _db.courseStudents.ToList();
            IEnumerable<Teacher> teachers = _db.teachers.ToList();


            string name = form["name"];
            string pass = form["password"];
            string email = form["tEmail"];

            Course c = new Course();

            foreach (Teacher teach in teachers)
            {
                foreach (Course course in courses)
                {
                    if (teach.EmailAddress == email && name==course.CourseName)
                    {
                        c = course;
                        c.teacherId = teach.Id;
                        c.teacher = teach;

                    }
                }
            }

            CourseStudent css = new CourseStudent();
            foreach (Student student in students)
            {
                if (student.Id == iddd)
                {
                    student.courses.Add(c);
                    css.course = c;
                    css.student = student;
                    css.StudentId = student.Id;
                    css.CourseId = c.Id;
                    break;
                }
            }

            Console.WriteLine(c.Id + " " + iddd);
            _db.courseStudents.Add(css);
            
            _db.SaveChanges();

            return View(courses);
        }
        public IActionResult Report()
        {
            IEnumerable<Report> reports = _db.reports.ToList();
            return View(reports);
        }
        public IActionResult QuizInfo()
        {
            return View();
        }
    }
}
