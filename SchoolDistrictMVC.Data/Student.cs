using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDistrictMVC.Data
{
    public enum GradeType
    {
        [Display(Name = "1st")]
        First,
        [Display(Name = "2nd")]
        Second,
        [Display(Name = "3rd")]
        Third,
        [Display(Name = "4th")]
        Fourth,
        [Display(Name = "5th")]
        Fifth,
        [Display(Name = "6th")]
        Sixth,
        [Display(Name = "7th")]
        Seventh,
        [Display(Name = "8th")]
        Eighth,
        [Display(Name = "9th")]
        Nineth,
        [Display(Name = "10th")]
        Tenth,
        [Display(Name = "11th")]
        Eleventh,
        [Display(Name = "12th")]
        Twelveth
    }
    public class Student
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
        [Required]
        public GradeType Grade { get; set; }
        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual List<Enrollment> Enrollment { get; set; }
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
