using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public IndexModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects.ToListAsync();
            }
        }
    }
}
