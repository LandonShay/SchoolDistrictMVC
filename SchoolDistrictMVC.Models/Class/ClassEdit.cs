using SchoolDistrictMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Class
{
    public class ClassEdit
    {
		public int Id { get; set; }
		[Display(Name = "Class Name")]
		public string Name { get; set; }
		public SubjectType Subject { get; set; }
		[Display(Name = "School")]
		public int SchoolId { get; set; }
		[Display(Name = "Teacher")]
		public int TeacherId { get; set; }
	}
}
