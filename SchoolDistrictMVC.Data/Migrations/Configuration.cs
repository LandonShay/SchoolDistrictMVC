namespace SchoolDistrictMVC.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDistrictMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SchoolDistrictMVC.Models.ApplicationDbContext";
        }

        protected override void Seed(SchoolDistrictMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var schools = new List<School>
            {
                new School {Name = "Fall Creek Elementary", Address = "12234 Fake Street"},
                new School {Name = "Fall Creek Middle School", Address = "52142 Some Street"},
                new School {Name = "Fall Creek High School", Address = "32523 That Street"},
            };

            schools.ForEach(s => context.Schools.AddOrUpdate(s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student {FirstName = "John", LastName = "Wick", DateOfBirth = DateTime.Parse("4/12/12"), Grade = GradeType.Sixth, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id },
                new Student {FirstName = "Steven", LastName = "Garcia", DateOfBirth = DateTime.Parse("8/22/13"), Grade = GradeType.Fifth, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id},
                new Student {FirstName = "Royce", LastName = "Young", DateOfBirth = DateTime.Parse("1/18/16"), Grade = GradeType.First, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id},
                new Student {FirstName = "Chuck", LastName = "Norris", DateOfBirth = DateTime.Parse("7/11/15"), Grade = GradeType.Second, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id, },
                new Student {FirstName = "John", LastName = "Lawrence", DateOfBirth = DateTime.Parse("2/9/08"), Grade = GradeType.Nineth, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id},
                new Student {FirstName = "Robert", LastName = "Plant", DateOfBirth = DateTime.Parse("6/1/07"), Grade = GradeType.Tenth, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id},
                new Student {FirstName = "Jim", LastName = "Douglas", DateOfBirth = DateTime.Parse("9/19/12"), Grade = GradeType.Sixth, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id},
                new Student {FirstName = "Percy", LastName = "de la Cruz", DateOfBirth = DateTime.Parse("3/14/13"), Grade = GradeType.Fifth, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id},
                new Student {FirstName = "Victoria", LastName = "Gondaker", DateOfBirth = DateTime.Parse("7/4/16"), Grade = GradeType.First, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id},
                new Student {FirstName = "Beatrice", LastName = "Rogers", DateOfBirth = DateTime.Parse("4/6/15"), Grade = GradeType.Second, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id},
                new Student {FirstName = "Johah", LastName = "Hill", DateOfBirth = DateTime.Parse("1/27/08"), Grade = GradeType.Nineth, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id},
                new Student {FirstName = "Andrew", LastName = "Baker", DateOfBirth = DateTime.Parse("11/12/07"), Grade = GradeType.Tenth, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id},
                new Student {FirstName = "Alex", LastName="Smith", DateOfBirth = DateTime.Parse("4/16/10"), Grade = GradeType.Twelveth, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id },
                new Student {FirstName = "George", LastName="Brown", DateOfBirth = DateTime.Parse("7/8/14"), Grade = GradeType.Seventh, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id },
            };

            students.ForEach(s => context.Students.AddOrUpdate(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher {FirstName = "Ryan", LastName="Jenkins", DateOfBirth = DateTime.Parse("5/2/87"), SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id },
                new Teacher {FirstName = "Bobby", LastName="Jones", DateOfBirth = DateTime.Parse("1/24/98"), SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id },
                new Teacher {FirstName = "Anne", LastName="Carter", DateOfBirth = DateTime.Parse("2/4/90"), SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id },
                new Teacher {FirstName = "Trisha", LastName="White", DateOfBirth = DateTime.Parse("11/23/95"), SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id },
                new Teacher {FirstName = "Larry", LastName="David", DateOfBirth = DateTime.Parse("4/16/93"), SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id },
                new Teacher {FirstName = "Reggie", LastName="Miller", DateOfBirth = DateTime.Parse("7/8/89"), SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id },
            };

            teachers.ForEach(t => context.Teachers.AddOrUpdate(t));
            context.SaveChanges();

            var classes = new List<Class>
            {
                new Class {Name = "Math 101", TeacherId = 1, Subject = SubjectType.Math, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id, },
                new Class {Name = "Science 101", TeacherId = 1, Subject = SubjectType.Science, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id, },
                new Class {Name = "Elementary P.E.", TeacherId = 2, Subject = SubjectType.PhysicalEducation, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id, },
                new Class {Name = "History 101", TeacherId = 2, Subject = SubjectType.History, SchoolId = schools.Single(d => d.Name == "Fall Creek Elementary").Id, },
                new Class {Name = "Algebra", TeacherId = 3, Subject = SubjectType.Math, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id, },
                new Class {Name = "Wellness", TeacherId = 3, Subject = SubjectType.Health, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id, },
                new Class {Name = "U.S. History", TeacherId = 4, Subject = SubjectType.History, SchoolId = schools.Single(d => d.Name == "Fall Creek Middle School").Id, },
                new Class {Name = "Calculus", TeacherId = 5, Subject = SubjectType.Math, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id, },
                new Class {Name = "World History", TeacherId = 6, Subject = SubjectType.History, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id, },
                new Class {Name = "Economics", TeacherId = 5, Subject = SubjectType.Math, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id, },
                new Class {Name = "Swimming", TeacherId = 6, Subject = SubjectType.PhysicalEducation, SchoolId = schools.Single(d => d.Name == "Fall Creek High School").Id, },
            };

            classes.ForEach(t => context.Classes.AddOrUpdate(t));
            context.SaveChanges();
        }
    }
}
