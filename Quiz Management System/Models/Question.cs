using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public string Statement { get; set; }
        [Required]
        public int marks    { get; set; }
        [Required]
        public string Answer { get; set; }
        public List<Choice> choices { get; set; }
        [Required]
        public bool isMCQ { get; set; }
        public Quiz quiz { get; set; }
        public int quizId { get; set; }
    }
}
