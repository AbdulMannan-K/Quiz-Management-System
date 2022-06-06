using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_Management_System.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Marks { get; set; }
        [Required]
        public bool Taken { get; set; }
        public int courseId { get; set; }
        [Required]
        public Course Course { get; set; }
        public int quizMaterialId { get; set; }
        [ForeignKey("QuizMaterial")]
        public QuizMaterial quizMaterial { get; set; } 
        [Required]
        public List<Question> Questions { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
