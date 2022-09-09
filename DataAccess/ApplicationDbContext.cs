using application_api.Models;
using Microsoft.EntityFrameworkCore;

namespace application_api.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ActiveCourse> ActiveCourses { get; set; }
        public DbSet<Delegate> Delegates { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
