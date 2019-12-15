using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore3.Models
{
    public static class ContosoUniversityContextExtensions
    {
        private static bool seed_created = false;
        public static void UseMemoryDataSeed([NotNullAttribute] this ContosoUniversityContext context)
        {
            context.Database.EnsureCreated();

            if (seed_created == false)
            {

                var person = new Person()
                {
                    FirstName = "Bob",
                    LastName = "",
                    HireDate = DateTime.Now,
                    EnrollmentDate = DateTime.Now,
                    Discriminator = "Instructor"
                };

                var department = new Department()
                {
                    Name = "MIS",
                    Budget = 1000,
                    StartDate = DateTime.Now
                };

                department.Instructor = person;

                context.Department.Add(department);
                context.SaveChanges();
                seed_created = true;
            }
        }

    }
}