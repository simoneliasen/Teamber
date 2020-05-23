using ContosoUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data {
    public static class DbInitializer {
        public static void Initialize(TeamberContext context)
        {
            context.Database.EnsureCreated();
            //DbInitializer.Initialize(context);
            //return;   // DB has been seeded
            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstMidName="John",LastName="Doe",EmpTeamDate=DateTime.Parse("2019-09-01"),JobTitle="HR Manager",PersonalityType="ISTP",IsManager=true,Username="Admin",Password="123"},

    };

            foreach (Employee s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();
        }
    }
}