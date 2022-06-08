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
        public IActionResult QuizInfo()
        {
            return View();
        }


        public IActionResult Quiz()
        {
            IEnumerable<Models.Quiz> quizzes = _db.quizzes.ToList();
            List<Models.Quiz> quizzes1 = new List<Quiz>();
            IEnumerable<Course> courses = _db.courses.ToList();
            List<Course> courses1 = new List<Course>();
            int id = -1;
            int.TryParse(HttpContext.Session.GetString("Id"), out id);

            foreach (var course in courses)
            {
                if (course.teacherId == id && !courses1.Contains(course))
                {
                    courses1.Add(course);
                }
            }

            foreach (var quizz in quizzes)
            {

                foreach (var course in courses1)
                {

                    if (course.Id == quizz.courseId ) {
                        quizzes1.Add(quizz); 
                    }
                }
            }
            ViewModel vm = new ViewModel();
            vm.courses = courses1;
            vm.quizzes = quizzes1;

            if (HttpContext.Session.GetString("Id") != null)
            {
                return View(vm);
            }
            else
            {
                return RedirectToAction("login", "LoginSignup");
            }
        }
        [HttpPost]
        public IActionResult Quiz(IFormCollection form)
        {
            IEnumerable<Course> courses = _db.courses.ToList();

            var options = form["option"];
            var cours = form["course"].ToString();
            var name = form["name"].ToString();
            var weight = form["weight"].ToString().ToArray();
            var allOptions = options.ToString().Split(',').ToArray();
            var question = form["statment"].ToString().Split(',').ToArray();
            var answers = form["answer"].ToString().Split(',').ToArray();
            var values = form["type"].ToString().Split(',').ToArray();
            var date = form["date"].ToString();
            List<Question> questions = new List<Question>();
            int totalMarks = 0;
            for(int i=0,j=0; i< question.Length; i++)
            {
                Question q = new Question();
                q.choices = new List<Choice>();
                q.Statement = question[i];
                q.marks = weight[i];
                totalMarks += q.marks;
                q.Answer = answers[i];
                if (values[i] == "MCQ") {
                    q.isMCQ = true;
                    for (int a = 0; a < 4; a++) {
                        Choice c = new Choice();
                        c.choice = allOptions[j++];
                        q.choices.Add(c);
                    }
                }
                else q.isMCQ = false;
                questions.Add(q);
            }
            Quiz quiz = new Quiz();
            quiz.Name = name;
            quiz.Marks = totalMarks;
            Course cc = new Course();
            foreach(Course course in courses)
            {
                Console.WriteLine("testttt " + course.CourseName + " " + cours);
                if (course.CourseName == cours) { cc = course; break; }
            }
            quiz.Course = cc;
            Console.WriteLine("test " + cc.Id);
            quiz.Course.CourseName = cc.CourseName;
            quiz.courseId = cc.Id;
            QuizMaterial quizMaterial = new QuizMaterial();
            quizMaterial.links = new List<Link>();
            Link link = new Link(); link.link = "d.com";link.quizMaterialId = quizMaterial.Id;
            quizMaterial.links.Add(link);
            quizMaterial.description = "Just for testing purposes" ;
            quiz.quizMaterial = quizMaterial;
            quiz.quizMaterialId=quizMaterial.Id;
            quiz.date = Convert.ToDateTime(date);
            quiz.Taken = false;
            quiz.Questions = questions;
            _db.quizzes.Add(quiz);
            Console.WriteLine(allOptions[0].ToString());
            _db.SaveChanges();

            IEnumerable<Models.Quiz> quizzes = _db.quizzes.ToList();
            List<Models.Quiz> quizzes1 = new List<Quiz>();
            List<Course> courses1 = new List<Course>();
            int id = -1;
            int.TryParse(HttpContext.Session.GetString("Id"), out id);
            foreach (var course in courses)
            {
                if (course.teacherId == id && !courses1.Contains(course)) courses1.ToList().Add(course);
            }
            foreach (var quizz in quizzes)
            {
                foreach (var course in courses1)
                {
                    if (course.Id == quizz.courseId) quizzes1.ToList().Add(quizz);
                }
            }



            ViewModel vm = new ViewModel();
            vm.courses = courses1;
            vm.quizzes = quizzes1;
            return View(vm);
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginSignup");
            }

        }

        public IActionResult Course() {
            IEnumerable<Course> courses = _db.courses.ToList();

            if (HttpContext.Session.GetString("Id") != null)
            {
                return View(courses);
            }
            else
            {
                return RedirectToAction("login", "LoginSignup");
            }

        }

        [HttpPost]
        public IActionResult Course(IFormCollection form)
        {
            IEnumerable<Course> courses = _db.courses.ToList();
            IEnumerable<Teacher> teachers = _db.teachers.ToList();

            int id = -1;
            int.TryParse(HttpContext.Session.GetString("Id"), out id);

            Console.WriteLine(id);

            Course c = new Course();
            string name = form["name"];
            string pass = form["password"];
            c.CourseName = name;
            c.password = pass;
            c.teacherId = id;
            foreach(Teacher t in teachers) {
                if (t.Id == id)
                {
                    c.teacher = t;
                    break;
                }
            }
            _db.courses.Add(c);
            _db.SaveChanges();
            courses.ToList().Add(c);
            return View(courses);
        }

        public IActionResult Report()
        {
            IEnumerable<Report> reports = _db.reports.ToList();
            return View(reports);
        }

        public IActionResult ReportDetail(Report report)
        {
            return View(report);
        }

    }
}
