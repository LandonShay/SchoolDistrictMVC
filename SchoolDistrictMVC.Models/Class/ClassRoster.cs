using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Class
{
    public class ClassRoster
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Student { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    }
}
