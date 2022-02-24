using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Services
{
    public class StudentService
    {
        public bool CreateStudent(StudentCreate student)
        {
            var entity = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                SchoolId = student.SchoolId,
                Grade = student.Grade,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StudentListItem> GetStudentList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Students.Select(s => new StudentListItem
                {
                    Id = s.Id,
                    Name = s.FullName,
                    DateOfBirth = s.DateOfBirth,
                    Grade = s.Grade,
                    School = s.School.Name
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Students.ToList();
            }
        }

        public StudentDetail GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Students.Single(e => e.Id == id);
                return new StudentDetail
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    DateOfBirth = entity.DateOfBirth,
                    School = entity.School.Name,
                    Grade = entity.Grade,
                };
            }
        }

        public IEnumerable<StudentClasses> ViewClasses(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Select(s => new StudentClasses
                {
                    Id = s.Id,
                    Class = s.Class.Name,
                    ClassId = s.ClassId,
                    Teacher = s.Class.Teacher.FullName,
                    StudentId = s.StudentId,
                    Student = s.Student.FullName,
                }).Where(c => c.StudentId == id);

                return query.ToArray().OrderBy(s => s.Class);
            }
        }

        public bool UpdateStudent(StudentEdit student)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Students.Single(e => e.Id == student.Id);

                entity.FirstName = student.FirstName;
                entity.LastName = student.LastName;
                entity.DateOfBirth = student.DateOfBirth;
                entity.Grade = student.Grade;
                entity.SchoolId = student.SchoolId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Students.Single(e => e.Id == id);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
