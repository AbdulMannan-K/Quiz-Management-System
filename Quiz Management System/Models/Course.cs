using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public List<Student> students { get; set; }
        public int? teacherId { get; set; }
        public Teacher? teacher { get; set; }
        public List<Quiz> quizzes { get; set; }

    }
}
