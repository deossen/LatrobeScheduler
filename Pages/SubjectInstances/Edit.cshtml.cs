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

namespace LaTrobeScheduler.Pages.SubjectInstances
{
    public class EditModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public EditModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectInstance SubjectInstance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubjectInstances == null)
            {
                return NotFound();
            }

            var subjectinstance =  await _context.SubjectInstances.FirstOrDefaultAsync(m => m.SubjectInstanceID == id);
            if (subjectinstance == null)
            {
                return NotFound();
            }
            SubjectInstance = subjectinstance;
           ViewData["LecturerID"] = new SelectList(_context.Lecturers, "LecturerID", "EmailAddress");
           ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SubjectInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectInstanceExists(SubjectInstance.SubjectInstanceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubjectInstanceExists(int id)
        {
          return _context.SubjectInstances.Any(e => e.SubjectInstanceID == id);
        }
    }
}
