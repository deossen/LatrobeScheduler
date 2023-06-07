using LaTrobeUniversity.Models;

namespace LaTrobeScheduler.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public int WorkLoad { get; set; }
        public string KnownSubjects { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<SubjectInstance> SubjectInstances { get; set; }
    }
}