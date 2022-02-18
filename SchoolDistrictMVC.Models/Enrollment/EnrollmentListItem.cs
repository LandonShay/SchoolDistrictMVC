using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Enrollment
{
    public class EnrollmentListItem
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public string Class { get; set; }
        public string School { get; set; }
        public int StudentId { get; set; }
    }
}
