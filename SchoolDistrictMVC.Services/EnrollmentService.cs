using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Services
{
    public class EnrollmentService
    {
        public bool CreateEnrollment(EnrollmentCreate enroll, int id)
        {
            var entity = new Enrollment()
            {
                StudentId = enroll.StudentId,
                ClassId = id
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EnrollmentListItem> GetEnrollmentList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Select(s => new EnrollmentListItem
                {
                    Id = s.Id,
                    Student = s.Student.FullName,
                    Class = s.Class.Name
                });
                return query.ToArray();
            }
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Enrollments.ToList();
            }
        }

        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Enrollments.Single(e => e.Id == id);
                return new EnrollmentDetail
                {
                    Id = entity.Id,
                    StudentId = entity.StudentId,
                    ClassId = entity.ClassId,
                    StudentName = entity.Student.FullName,
                    ClassName = entity.Class.Name
                };
            }
        }

        public bool UpdateEnrollment(EnrollmentEdit enroll)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Enrollments.Single(e => e.Id == enroll.Id);

                entity.StudentId = enroll.StudentId;
                entity.ClassId = enroll.ClassId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEnrollment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Enrollments.Single(e => e.Id == id);

                ctx.Enrollments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
