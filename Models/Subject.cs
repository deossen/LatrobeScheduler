using LaTrobeScheduler.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaTrobeScheduler.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}