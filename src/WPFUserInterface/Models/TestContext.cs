using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WPFUserInterface.Models;
using static WPFUserInterface.Models.Question;

namespace WPFUserInterface
{
    public class TestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=test.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Question>()
                .Property(q => q.RightLeft)
                .HasConversion(
                    q => q.ToString(),
                    q => (Hemisphere)Enum.Parse(typeof(Hemisphere), q));
        }

    }
}
