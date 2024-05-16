using Microsoft.EntityFrameworkCore;

namespace GTCLExam.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Designation> Designations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GTCLDBBExam;Trusted_Connection=True;");
        }

    }
}
