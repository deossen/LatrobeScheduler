using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.Lecturers
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
            return Page();
        }

        [BindProperty]
        public Lecturer Lecturer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyLecturer = new Lecturer();

            if (await TryUpdateModelAsync<Lecturer>(
                emptyLecturer,
                "lecturer",   // Prefix for form value.
                l => l.FirstMidName, l => l.LastName, l => l.WorkLoad, l => l.EmailAddress, l => l.KnownSubjects))
            {
                _context.Lecturers.Add(emptyLecturer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
