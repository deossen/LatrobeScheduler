using LaTrobeScheduler.Models.SchedulerViewModels;
using LaTrobeScheduler.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchedulerContext _context;

        public AboutModel(SchedulerContext context)
        {
            _context = context;
        }

        public IList<SubjectInstanceDateGroup> SubjectInstances { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<SubjectInstanceDateGroup> data =
                from subjectInstance in _context.SubjectInstances
                group subjectInstance by subjectInstance.StartDate into dateGroup
                select new SubjectInstanceDateGroup()
                {
                    StartDate = dateGroup.Key,
                    SubjectCount = dateGroup.Count()
                };

            SubjectInstances = await data.AsNoTracking().ToListAsync();
        }
    }
}