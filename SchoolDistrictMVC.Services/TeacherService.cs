using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Services
{
    public class TeacherService
    {
        public bool CreateTeacher(TeacherCreate teacher)
        {
            var entity = new Teacher()
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                SchoolId = teacher.SchoolId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeacherListItem> GetTeacherList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Teachers.Select(s => new TeacherListItem
                {
                    Id = s.Id,
                    Name = s.FullName,
                    DateOfBirth = s.DateOfBirth,
                    School = s.School.Name
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Teachers.ToList();
            }
        }

        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Single(e => e.Id == id);
                return new TeacherDetail
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    DateOfBirth = entity.DateOfBirth,
                    School = entity.School.Name,
                };
            }
        }

        public IEnumerable<TeacherClasses> ViewClasses(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Classes.Select(s => new TeacherClasses
                {
                    Id = s.Id,
                    Class = s.Name,
                    ClassId = s.Id,
                    Teacher = s.Teacher.FullName,
                    TeacherId = s.TeacherId,
                    School = s.School.Name
                }).Where(c => c.TeacherId == id);

                return query.ToArray().OrderBy(s => s.Class);
            }
        }

        public bool UpdateTeacher(TeacherEdit teacher)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Single(e => e.Id == teacher.Id);

                entity.FirstName = teacher.FirstName;
                entity.LastName = teacher.LastName;
                entity.DateOfBirth = teacher.DateOfBirth;
                entity.SchoolId = teacher.SchoolId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeacher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Single(e => e.Id == id);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
