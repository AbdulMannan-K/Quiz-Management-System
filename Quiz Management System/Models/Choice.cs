using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        public string choice { get; set; }

        public Question quesion { get; set; }
        public int questionId { get; set; }
    }
}
