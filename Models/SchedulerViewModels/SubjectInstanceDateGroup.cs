using System;
using System.ComponentModel.DataAnnotations;

namespace LaTrobeScheduler.Models.SchedulerViewModels
{
    public class SubjectInstanceDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        public int SubjectCount { get; set; }
    }
}