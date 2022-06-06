using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string link { get; set; }

        public int quizMaterialId { get; set; }
    }
}
