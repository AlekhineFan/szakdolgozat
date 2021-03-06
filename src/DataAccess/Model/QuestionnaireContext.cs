﻿using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Model
{
    public class QuestionnaireContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=..\..\sqlite.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Question>()
                .Property(q => q.Hemisphere)
                .HasConversion(
                    q => q.ToString(),
                    q => (Hemisphere)Enum.Parse(typeof(Hemisphere), q));

            modelBuilder
                .Entity<Subject>()
                .Property(q => q.Gender)
                .HasConversion(
                    q => q.ToString(),
                    q => (Gender)Enum.Parse(typeof(Gender), q));
        }
    }
}