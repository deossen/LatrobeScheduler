using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.Lecturers
{
    public class DetailsModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public DetailsModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

      public Lecturer Lecturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            // var lecturer = await _context.Lecturers.FirstOrDefaultAsync(m => m.LecturerID == id);

            Lecturer = await _context.Lecturers
        .Include(s => s.SubjectInstances)
        .ThenInclude(e => e.Subject)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.LecturerID == id);

            if (Lecturer == null)
            {
                return NotFound();
            }
            else 
            {
                Lecturer = Lecturer;
            }
            return Page();
        }
    }
}
