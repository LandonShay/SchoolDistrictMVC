using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Services
{
    public class SchoolService
    {
        public bool CreateSchool(SchoolCreate school)
        {
            var entity = new School()
            {
                Name = school.Name,
                Address = school.Address,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SchoolListItem> GetSchoolsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Schools.Select(s => new SchoolListItem
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address
                });
                return query.ToArray();
            }
        }

        public IEnumerable<School> GetSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Schools.ToList();
            }
        }

        public SchoolDetail GetSchoolById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Schools.Single(e => e.Id == id);
                return new SchoolDetail
                {
                    SchoolId = entity.Id,
                    Name = entity.Name,
                    Address = entity.Address
                };
            }
        }

        public bool UpdateSchool(SchoolEdit school)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Schools.Single(e => e.Id == school.SchoolId);

                entity.Name = school.Name;
                entity.Address = school.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchool(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Schools.Single(e => e.Id == id);

                ctx.Schools.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
