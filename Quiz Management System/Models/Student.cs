using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Student:User
    {
        public List<Course> courses { get; set; }
    }
}
