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
    public class DetailsModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public DetailsModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

      public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }
            else 
            {
                Subject = subject;
            }
            return Page();
        }
    }
}
