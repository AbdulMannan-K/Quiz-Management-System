using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Teacher:User
    {

        public List<Course> Courses { get; set; }
    }
}
