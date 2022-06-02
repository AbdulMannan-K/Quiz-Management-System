using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public List<Student> students { get; set; }
        [Required]
        public Teacher teacher { get; set; }
        public List<Quiz> quizzes { get; set; }

    }
}
