using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<EmpTeam> EmpTeams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<EmpQuestionnaire> EmpQuestionnaires { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<EmpTeam>().ToTable("EmpTeam");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Questionnaire>().ToTable("Questionnaire");
            modelBuilder.Entity<EmpQuestionnaire>().ToTable("EmpQuestionnaire");

        }
    }
}