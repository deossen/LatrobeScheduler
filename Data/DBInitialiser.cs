using LaTrobeScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace LaTrobeScheduler.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchedulerContext context)
        {
            // Look for any students.
            if (context.Lecturers.Any())
            {
                return;   // DB has been seeded
            }

            var lecturers = new Lecturer[]
            {
                new Lecturer{FirstMidName="Carson",LastName="Alexander",WorkLoad=1, EmailAddress="ca@latrobe.edu.au", KnownSubjects="SPX"},
                new Lecturer{FirstMidName="Meredith",LastName="Alonso",WorkLoad=1, EmailAddress="ma@latrobe.edu.au", KnownSubjects="IOX"},
                new Lecturer{FirstMidName="Arturo",LastName="Anand",WorkLoad=1, EmailAddress="aa@latrobe.edu.au", KnownSubjects="OTX"},
                new Lecturer{FirstMidName="Gytis",LastName="Barzdukas",WorkLoad=1, EmailAddress="gb@latrobe.edu.au", KnownSubjects="PEX"},
                new Lecturer{FirstMidName="Yan",LastName="Li",WorkLoad=1, EmailAddress="yl@latrobe.edu.au", KnownSubjects="PAX, PBX"},
                new Lecturer{FirstMidName="Peggy",LastName="Justice",WorkLoad=1, EmailAddress="pj@latrobe.edu.au", KnownSubjects="SPX"},
                new Lecturer{FirstMidName="Laura",LastName="Norman",WorkLoad=1, EmailAddress="ln@latrobe.edu.au", KnownSubjects="OTX"},
                new Lecturer{FirstMidName="Nino",LastName="Olivetto",WorkLoad=1, EmailAddress="no@latrobe.edu.au", KnownSubjects="IOX, OTX"}
            };

            context.Lecturers.AddRange(lecturers);
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject{SubjectName="SPX - Sustainability",SubjectID=101},
                new Subject{SubjectName="IOX - Intermidaite Object Oriented Programming",SubjectID=102},
                new Subject{SubjectName="OTX - Internet of Things",SubjectID=203},
                new Subject{SubjectName="PEX - Professional Industry",SubjectID=304},
                new Subject{SubjectName="PAX - Industry Project A",SubjectID=305},
                new Subject{SubjectName="PBX - Industry Project B",SubjectID=306},
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var subjectInstances = new SubjectInstance[]
            {
                new SubjectInstance{LecturerID=1,SubjectID=101,StudentNumbers=20,StartDate=DateTime.Parse("2024-01-01")},
                new SubjectInstance{LecturerID=1,SubjectID=101,StudentNumbers=20,StartDate=DateTime.Parse("2024-02-01")},
                new SubjectInstance{LecturerID=1,SubjectID=101,StudentNumbers=20,StartDate=DateTime.Parse("2024-03-01")},
                new SubjectInstance{LecturerID=2,SubjectID=102,StudentNumbers=20,StartDate=DateTime.Parse("2024-01-01")},
                new SubjectInstance{LecturerID=2,SubjectID=102,StudentNumbers=20,StartDate=DateTime.Parse("2024-02-01")},
                new SubjectInstance{LecturerID=2,SubjectID=102,StudentNumbers=20,StartDate=DateTime.Parse("2024-03-01")},
                new SubjectInstance{LecturerID=3,SubjectID=203,StudentNumbers=20,StartDate=DateTime.Parse("2024-01-01")},
                new SubjectInstance{LecturerID=4,SubjectID=304,StudentNumbers=20,StartDate=DateTime.Parse("2024-01-01")},
                new SubjectInstance{LecturerID=4,SubjectID=304,StudentNumbers=20,StartDate=DateTime.Parse("2024-02-01")},
                new SubjectInstance{LecturerID=5,SubjectID=305,StudentNumbers=20,StartDate=DateTime.Parse("2024-01-01")},
                new SubjectInstance{LecturerID=5,SubjectID=305,StudentNumbers=20,StartDate=DateTime.Parse("2024-02-01")},
                new SubjectInstance{LecturerID=7,SubjectID=203,StudentNumbers=20,StartDate=DateTime.Parse("2024-03-01")},
            };

            context.SubjectInstances.AddRange(subjectInstances);
            context.SaveChanges();
        }
    }
}