using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Data
{
	public enum SubjectType
	{
		Math,
		History,
		Science,
		Health,
		Economics,
		[Display(Name = "P.E.")]
		PhysicalEducation
	}

	public class Class
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public SubjectType Subject { get; set; }
		[Required]
		public string Name { get; set; }
		[ForeignKey(nameof(Teacher))]
		public int TeacherId { get; set; }
		[Required]
		[ForeignKey(nameof(School))]
		public int SchoolId { get; set; }
		public virtual School School { get; set; }
		public virtual Teacher Teacher { get; set; }
		public virtual List<Enrollment> Enrollment { get; set; }
	}
}
