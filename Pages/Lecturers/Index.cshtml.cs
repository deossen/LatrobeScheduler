using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;

namespace LaTrobeScheduler.Pages.Lecturers
{
    public class IndexModel : PageModel
    {
        private readonly SchedulerContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SchedulerContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Lecturer> Lecturers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;


            IQueryable<Lecturer> lecturersIQ = from l in _context.Lecturers
                                             select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lecturersIQ = lecturersIQ.Where(l => l.LastName.Contains(searchString)
                                       || l.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    lecturersIQ = lecturersIQ.OrderByDescending(l => l.LastName);
                    break;
                
                default:
                    lecturersIQ = lecturersIQ.OrderBy(l => l.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Lecturers = await PaginatedList<Lecturer>.CreateAsync(
                lecturersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
