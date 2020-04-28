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

            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Employee{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Employee{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Employee{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Employee{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Employee{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };
            foreach (Employee s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();

            var teams = new Team[]
            {
                new Team{TeamID=1050,Title="Chemistry",Credits=3},
                new Team{TeamID=4022,Title="Microeconomics",Credits=3},
                new Team{TeamID=4041,Title="Macroeconomics",Credits=3},
                new Team{TeamID=1045,Title="Calculus",Credits=4},
                new Team{TeamID=3141,Title="Trigonometry",Credits=4},
                new Team{TeamID=2021,Title="Composition",Credits=3},
                new Team{TeamID=2042,Title="Literature",Credits=4}
            };
            foreach (Team c in teams)
            {
                context.Teams.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{EmployeeID=1,TeamID=1050,Grade=Grade.A},
                new Enrollment{EmployeeID=1,TeamID=4022,Grade=Grade.C},
                new Enrollment{EmployeeID=1,TeamID=4041,Grade=Grade.B},
                new Enrollment{EmployeeID=2,TeamID=1045,Grade=Grade.B},
                new Enrollment{EmployeeID=2,TeamID=3141,Grade=Grade.F},
                new Enrollment{EmployeeID=2,TeamID=2021,Grade=Grade.F},
                new Enrollment{EmployeeID=3,TeamID=1050},
                new Enrollment{EmployeeID=4,TeamID=1050},
                new Enrollment{EmployeeID=4,TeamID=4022,Grade=Grade.F},
                new Enrollment{EmployeeID=5,TeamID=4041,Grade=Grade.C},
                new Enrollment{EmployeeID=6,TeamID=1045},
                new Enrollment{EmployeeID=7,TeamID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}