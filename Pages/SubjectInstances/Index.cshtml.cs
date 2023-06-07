using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.SubjectInstances
{
    public class IndexModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public IndexModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

        public IList<SubjectInstance> SubjectInstance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubjectInstances != null)
            {
                SubjectInstance = await _context.SubjectInstances
                .Include(s => s.Lecturer)
                .Include(s => s.Subject).ToListAsync();
            }
        }
    }
}
