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
    public class DetailsModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public DetailsModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

      public SubjectInstance SubjectInstance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubjectInstances == null)
            {
                return NotFound();
            }

            var subjectinstance = await _context.SubjectInstances.FirstOrDefaultAsync(m => m.SubjectInstanceID == id);
            if (subjectinstance == null)
            {
                return NotFound();
            }
            else 
            {
                SubjectInstance = subjectinstance;
            }
            return Page();
        }
    }
}
