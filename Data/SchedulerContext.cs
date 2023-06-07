using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaTrobeScheduler.Models;
using LaTrobeUniversity.Models;

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
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<SubjectInstance>().ToTable("SubjectInstance");
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
        }

        // public DbSet<LaTrobeScheduler.Models.Lecturer> Lecturer { get; set; } = default!;
    }
}
