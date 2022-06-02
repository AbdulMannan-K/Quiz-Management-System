using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_Management_System.Models
{
    public class QuizMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String description { get; set; }
        public List<Link> links { get; set; }
    }
}
