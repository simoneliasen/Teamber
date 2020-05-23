using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data {
    public class TeamberContext : DbContext {
        public TeamberContext(DbContextOptions<TeamberContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<EmpTeam> EmpTeams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<EmpQuestionnaire> EmpQuestionnaires { get; set; }
        public DbSet<QuestionnaireCompetence> QuestionnaireCompetences { get; set; }
        public DbSet<TeamCriteria> TeamCriterias { get; set; }
        public DbSet<EmployeeCompetence> EmployeeCompetences { get; set; }
        public DbSet<TeamQuestionnaire> TeamQuestionnaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<EmpTeam>().ToTable("EmpTeam");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Questionnaire>().ToTable("Questionnaire");
            modelBuilder.Entity<EmpQuestionnaire>().ToTable("EmpQuestionnaire");
            modelBuilder.Entity<QuestionnaireCompetence>().ToTable("QuestionnaireCompetence");
            modelBuilder.Entity<TeamCriteria>().ToTable("TeamCriteria");
            modelBuilder.Entity<EmployeeCompetence>().ToTable("EmployeeCompetence");
            modelBuilder.Entity<TeamQuestionnaire>().ToTable("TeamQuestionnaire");
        }
    }
}