using LaTrobeScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaTrobeScheduler.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstMidName { get; set; }
        [Required]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("WorkLoad")]
        [Range(0, 38)]
        [Display(Name = "Weekly Hours 0 - 38")]
        public int WorkLoad { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "known subjects cannot be longer than 50 characters.")]
        [Column("KnownSubjects")]
        [Display(Name = "Known Subjects")]
        public string KnownSubjects { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Email Address cannot be longer than 50 characters.")]
        [Column("EmailAddress")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}