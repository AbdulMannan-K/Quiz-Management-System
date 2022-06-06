using System.ComponentModel.DataAnnotations;

namespace Quiz_Management_System.Models
{
    public class Report
    {
        [Key]
        public int ReportNumber { get; set; }
        public int studentId { get; set; }

        [Required]
        public Student IssuedBy { get; set; }
        public int teacherId { get; set; }
        [Required]
        public Teacher IssuedTo { get; set; }

    }
}
