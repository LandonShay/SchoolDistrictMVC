using SchoolDistrictMVC.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models
{
    public class ClassRosterRedo
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public List<StudentListItem> Students { get; set; }
    }
}
