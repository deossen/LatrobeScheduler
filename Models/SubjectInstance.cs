using LaTrobeScheduler.Models;
using System.ComponentModel.DataAnnotations;

namespace LaTrobeUniversity.Models
{

    public class SubjectInstance
    {
        public int SubjectInstanceID { get; set; }
        public int SubjectID { get; set; }
        public int LecturerID { get; set; }
        [DisplayFormat(NullDisplayText = "No Students")]
        public int StudentNumbers { get; set; }
        public DateTime StartDate { get; set; }
        
        public Lecturer Lecturer { get; set; }
        public Subject Subject { get; set; }

    }
}