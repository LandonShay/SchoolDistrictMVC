using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Enrollment
{
    public class EnrollmentDetail
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        [Display(Name = "Class")]
        public string ClassName { get; set; }
    }
}
