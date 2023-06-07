using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.Lecturers
{
    public class EditModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public EditModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lecturer Lecturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            Lecturer = await _context.Lecturers.FindAsync(id);

            if (Lecturer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var lecturerToUpdate = await _context.Lecturers.FindAsync(id);

            if (lecturerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Lecturer>(
                lecturerToUpdate,
                "lecturer",
                l => l.FirstMidName, l => l.LastName, l => l.WorkLoad, l => l.EmailAddress, l => l.KnownSubjects))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool LecturerExists(int id)
        {
          return _context.Lecturers.Any(e => e.LecturerID == id);
        }
    }
}
