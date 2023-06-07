using LaTrobeUniversity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaTrobeScheduler.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}