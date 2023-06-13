using LaTrobeScheduler.Models;
using System.ComponentModel.DataAnnotations;

namespace LaTrobeScheduler.Models
{

    public class SubjectInstance
    {
        public int SubjectInstanceID { get; set; }
        public int SubjectID { get; set; }
        public int LecturerID { get; set; }
        [DisplayFormat(NullDisplayText = "No Students")]
        public int StudentNumbers { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Month")]
        public DateTime StartDate { get; set; }
        
        public Lecturer Lecturer { get; set; }
        public Subject Subject { get; set; }

    }
}