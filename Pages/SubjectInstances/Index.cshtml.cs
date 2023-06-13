using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Data;
using LaTrobeScheduler.Models;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;

namespace LaTrobeScheduler.Pages.SubjectInstances
{
    public class IndexModel : PageModel
    {
        private readonly LaTrobeScheduler.Data.SchedulerContext _context;
        private readonly IConfiguration Configuration;


        public IndexModel(LaTrobeScheduler.Data.SchedulerContext context , IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string LecturerSort { get; set; }
        public string DateSort { get; set; }
        public string SubjectSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<SubjectInstance> SubjectInstances { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString)
        {
            

            if (_context.SubjectInstances != null)
            {
                //using System;
                CurrentSort = sortOrder;
                CurrentFilter = searchString;
                LecturerSort = String.IsNullOrEmpty(sortOrder) ? "lect_desc" : "";
                SubjectSort = String.IsNullOrEmpty(sortOrder) ? "subj_desc" : "subj";
                //SubjectSort = String.IsNullOrEmpty(sortOrder) ? "subj" : "";
                DateSort = sortOrder == "Date" ? "date_desc" : "Date";

                IQueryable<SubjectInstance> subjectInstancesIQ = from s in _context.SubjectInstances
                                                                 select s;
                
                if (!String.IsNullOrEmpty(searchString))
                {
                    //String LecturerString =ToString(Lecturer);

                  //  subjectInstancesIQ = subjectInstancesIQ.Where(s =>  s.Lecturer.Contains(searchString));
                                        //   || s.Subject.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "lect_desc":
                           subjectInstancesIQ = subjectInstancesIQ.OrderByDescending(s => s.Lecturer);
                          break;
                    case "Date":
                        subjectInstancesIQ = subjectInstancesIQ.OrderBy(s => s.StartDate);
                        break;
                      case "subj_desc":
                        subjectInstancesIQ = subjectInstancesIQ.OrderByDescending(s => s.Subject);
                      break;
                    case "date_desc":
                        subjectInstancesIQ = subjectInstancesIQ.OrderByDescending(s => s.StartDate);
                        break;
                    case "subj":
                       subjectInstancesIQ = subjectInstancesIQ.OrderBy(s => s.Subject);
                       break;
                    default:
                        subjectInstancesIQ = subjectInstancesIQ.OrderBy(s => s.Lecturer);
                        break;
                }

                SubjectInstances = await subjectInstancesIQ
                     .Include(s => s.Lecturer)
                    .Include(s => s.Subject).ToListAsync();

              

                // SubjectInstances = await _context.SubjectInstances
                // .Include(s => s.Lecturer)
                //.Include(s => s.Subject).ToListAsync();


            }
        }
    }
}
