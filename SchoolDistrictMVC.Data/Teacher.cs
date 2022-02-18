using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Data
{
    public class Teacher
    {
        private string _fullName;
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public string FullName
        {
            get
            {
                _fullName = $"{FirstName} {LastName}";
                return _fullName;
            }
            set { _fullName = value; }
        }
    }
}
