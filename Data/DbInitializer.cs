using ContosoUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            //DbInitializer.Initialize(context);
            return;   // DB has been seeded
            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstMidName="Carson",LastName="Alexander",EmpTeamDate=DateTime.Parse("2019-09-01"),JobTitle="Pro gamer",PersonalityType="GGGG",IsManager=true,Username="StoreDadler123",Password="hej123"},

    };
            return;

            foreach (Employee s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();

            var teams = new Team[]
            {
                new Team{TeamID=1050,Title="SoftwareBonanza",Synergy=13},
                new Team{TeamID=4022,Title="Festivalg.dk",Synergy=99},
                new Team{TeamID=4041,Title="billige-bajer.dk",Synergy=33},
                new Team{TeamID=1045,Title="Matador bare med fotomodeller",Synergy=44},
                new Team{TeamID=3141,Title="DetGodeTEam",Synergy=41},
                new Team{TeamID=2021,Title="Detdaarligeteam",Synergy=35},
                new Team{TeamID=2042,Title="LitteraturBøsserne",Synergy=64}
            };
            foreach (Team c in teams)
            {
                context.Teams.Add(c);
            }
            context.SaveChanges();

            var empTeams = new EmpTeam[]
            {
                new EmpTeam{EmployeeID=1,TeamID=1050},
                new EmpTeam{EmployeeID=1,TeamID=4022},
                new EmpTeam{EmployeeID=1,TeamID=4041},
                new EmpTeam{EmployeeID=2,TeamID=1045},
                new EmpTeam{EmployeeID=2,TeamID=3141},
                new EmpTeam{EmployeeID=2,TeamID=2021},
                new EmpTeam{EmployeeID=3,TeamID=1050},
                new EmpTeam{EmployeeID=4,TeamID=1050},
                new EmpTeam{EmployeeID=4,TeamID=4022},
                new EmpTeam{EmployeeID=5,TeamID=4041},
                new EmpTeam{EmployeeID=6,TeamID=1045},
                new EmpTeam{EmployeeID=7,TeamID=3141},
            };
            foreach (EmpTeam e in empTeams)
            {
                context.EmpTeams.Add(e);
            }
            context.SaveChanges();
        }
    }
}