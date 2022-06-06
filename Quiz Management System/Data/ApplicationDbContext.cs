using Microsoft.EntityFrameworkCore;
using Quiz_Management_System.Models;

namespace Quiz_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Name all the tables by DBSET
        public DbSet<Course> courses { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<QuizMaterial> QuizMaterials { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        public DbSet<CourseStudent> courseStudents { get; set; }
        public DbSet<Choice> choices { get; set; }
        public DbSet<Link> links { get; set; }


    }
}
