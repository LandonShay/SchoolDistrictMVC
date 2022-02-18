using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.School
{
    public class SchoolDetail
    {
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
