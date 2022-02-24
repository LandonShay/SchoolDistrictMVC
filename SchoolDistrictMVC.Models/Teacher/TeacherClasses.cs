using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Teacher
{
    public class TeacherClasses
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Teacher { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string School { get; set; }
    }
}
