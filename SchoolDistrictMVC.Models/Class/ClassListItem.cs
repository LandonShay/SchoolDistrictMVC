using SchoolDistrictMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Models.Class
{
    public class ClassListItem
    {
		public int Id { get; set; }
		public SubjectType Subject { get; set; }
		public string Name { get; set; }
		public string School { get; set; }
		public string Teacher { get; set; }
	}
}
