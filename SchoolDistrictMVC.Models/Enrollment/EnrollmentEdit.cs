using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Enrollment
{
    public class EnrollmentEdit
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
