using SchoolDistrictMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Class
{
    public class ClassCreate
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public SubjectType Subject { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[Display(Name = "School")]
		public int SchoolId { get; set; }
		[Required]
		[Display(Name = "Teacher")]
		public int TeacherId { get; set; }
	}
}
