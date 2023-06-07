using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.SubjectInstances
{
    public class CreateModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;

        public CreateModel(LaTrobeScheduler.Data.SchedulerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LecturerID"] = new SelectList(_context.Lecturers, "LecturerID", "EmailAddress");
        ViewData["SubjectID"] = new SelectList(_context.Subjects, "SubjectID", "SubjectID");
            return Page();
        }

        [BindProperty]
        public SubjectInstance SubjectInstance { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SubjectInstances.Add(SubjectInstance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
