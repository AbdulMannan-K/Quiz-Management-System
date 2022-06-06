namespace Quiz_Management_System.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public Student student { get; set; }
        public int StudentId { get; set; }
        public Course course { get; set; }
        public int CourseId  { get; set; }
    }
}
