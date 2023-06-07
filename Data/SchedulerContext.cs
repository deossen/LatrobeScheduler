using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Models;
// using LaTrobeUniversity.Models;

namespace LaTrobeScheduler.Data
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<SubjectInstance> SubjectInstances { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().ToTable(nameof(Subject))
            //    .HasMany(s => s.SubjectInstances)
              //  .WithMany(s => s.Subjects)
                ;
            modelBuilder.Entity<SubjectInstance>().ToTable(nameof(SubjectInstance));
            modelBuilder.Entity<Lecturer>().ToTable(nameof(Lecturer))
                //.HasMany(s => s.SubjectInstances)
                ;
        }

        // public DbSet<LaTrobeScheduler.Models.Lecturer> Lecturer { get; set; } = default!;
    }
}
