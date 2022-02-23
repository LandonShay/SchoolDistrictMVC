using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Class;
using SchoolDistrictMVC.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Services
{
    public class ClassService
    {
        public bool CreateClass(ClassCreate c)
        {
            var entity = new Class()
            {
                Subject = c.Subject,
                SchoolId = c.SchoolId,
                TeacherId = c.TeacherId,
                Name = c.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Classes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClassListItem> GetClassList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Classes.Select(c => new ClassListItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    School = c.School.Name,
                    Teacher = c.Teacher.FullName,
                    Subject = c.Subject,
                    NumberOfStudents = c.Enrollment.Count
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Class> GetClasses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Classes.ToList();
            }
        }

        public ClassDetail GetClassById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Classes.Single(e => e.Id == id);
                return new ClassDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Teacher = entity.Teacher.FullName,
                    School = entity.School.Name,
                    Subject = entity.Subject,
                };
            }
        }

        public bool UpdateClass(ClassEdit student)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Classes.Single(e => e.Id == student.Id);

                entity.Name = student.Name;
                entity.Subject = student.Subject;
                entity.TeacherId = student.TeacherId;
                entity.SchoolId = student.SchoolId;

                return ctx.SaveChanges() == 1;
            }
        }

        public ClassRosterRedo GetClassRoster(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Classes.Where(c => c.Id == id).First();

                var roster = new ClassRosterRedo
                {
                    ClassId = query.Id,
                    Name = query.Name,
                    Teacher = query.Teacher.FullName,
                    Students = query.Enrollment.Select(s => new Models.Student.StudentListItem
                    {
                        Id = s.Id,
                        Name = s.Student.FullName,
                        DateOfBirth = s.Student.DateOfBirth,
                        School = s.Student.School.Name,
                        Grade = s.Student.Grade,
                    }).ToList()
                };
                return roster;
            }
        }

        public bool DeleteClass(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Classes.Single(e => e.Id == id);

                ctx.Classes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
