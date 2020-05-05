using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public static class DbInitializer {
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
                new Employee{FirstMidName="Carson",LastName="Alexander",EmpTeamDate=DateTime.Parse("2019-09-01"),JobTitle="Pro gamer",PersonalityType="GGGG",IsManager=false,Username="StoreDadler123",Password="hej123"},
                new Employee{FirstMidName="Meredith",LastName="Alonso",EmpTeamDate=DateTime.Parse("2017-09-01"),JobTitle="MarketingNoerd",PersonalityType="ENTP",IsManager=false,Username="BigboiBoris",Password="hej123"},
                new Employee{FirstMidName="Arturo",LastName="Anand",EmpTeamDate=DateTime.Parse("2018-09-01"),JobTitle="Pro gamer",PersonalityType="JSTF",IsManager=false,Username="LongJohn472",Password="hej123"},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",EmpTeamDate=DateTime.Parse("2017-09-01"),JobTitle="Pro gamer",PersonalityType="gamer",IsManager=false,Username="FisseFred69",Password="hej123"},
                new Employee{FirstMidName="Yan",LastName="Li",EmpTeamDate=DateTime.Parse("2017-09-01"),JobTitle="slagsassiten",PersonalityType="entj",IsManager=false,Username="Kingkong47",Password="asdsa222"},
                new Employee{FirstMidName="Peggy",LastName="Justice",EmpTeamDate=DateTime.Parse("2016-09-01"),JobTitle="Pro gamer",PersonalityType="gamer",IsManager=false,Username="frederik272982",Password="12321asdas"},
                new Employee{FirstMidName="Laura",LastName="Norman",EmpTeamDate=DateTime.Parse("2018-09-01"),JobTitle="Saelger",PersonalityType="intj",IsManager=false,Username="lars1293",Password="21312asdasd"},
                new Employee{FirstMidName="Nino",LastName="Olivetto",EmpTeamDate=DateTime.Parse("2019-09-01"),JobTitle="Pro gamer",PersonalityType="hlgk",IsManager=false,Username="per10923",Password="123123asda"}

    };

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