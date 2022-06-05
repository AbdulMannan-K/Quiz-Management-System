using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quiz_Management_System.Data;
using Quiz_Management_System.Models;

namespace Quiz_Management_System.Controllers
{
    public class LoginSignup : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginSignup(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult signup()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult signup(User user,IFormCollection form)
        {
            var serializedUser = JsonConvert.SerializeObject(user);
            if (string.IsNullOrEmpty(form["Teacher"])) {
                Student s = JsonConvert.DeserializeObject<Student>(serializedUser);
                _db.students.Add(s);
            }
            else
            {
                Teacher t = JsonConvert.DeserializeObject<Teacher>(serializedUser);
                _db.teachers.Add(t);
            }   
            _db.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(User user, IFormCollection form) 
        {
            var serializedUser = JsonConvert.SerializeObject(user);
            if (string.IsNullOrEmpty(form["Teacher"]))
            {
                Student s = JsonConvert.DeserializeObject<Student>(serializedUser);
                var list = _db.students.ToList();
                for(int i=0; i < list.Count; i++)
                {
                    if (list[i].EmailAddress == s.EmailAddress && list[i].Password == s.Password)
                    {
                        Console.WriteLine("Successfull");
                        break;
                    }
                    else
                        Console.WriteLine("Sad in it");
                }
            }
            else
            {
                Teacher t = JsonConvert.DeserializeObject<Teacher>(serializedUser);
                var list = _db.teachers.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].EmailAddress == t.EmailAddress && list[i].Password == t.Password)
                    {
                        Console.WriteLine("Successfull");
                        break;
                    }
                    else
                        Console.WriteLine("Sad in it");
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
