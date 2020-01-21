﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFUserInterface;

namespace WPFUserInterface.Migrations
{
    [DbContext(typeof(QuestionnaireContext))]
    [Migration("20200121104059_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("WPFUserInterface.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PasswordID")
                        .HasColumnType("INTEGER");

                    b.HasKey("InstructorID");

                    b.HasIndex("PasswordID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Password", b =>
                {
                    b.Property<int>("PasswordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.HasKey("PasswordID");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionText")
                        .HasColumnType("TEXT");

                    b.Property<string>("RightLeft")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubjectID")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestionID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Instructor", b =>
                {
                    b.HasOne("WPFUserInterface.Models.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordID");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Question", b =>
                {
                    b.HasOne("WPFUserInterface.Models.Subject", null)
                        .WithMany("Questions")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("WPFUserInterface.Models.Subject", b =>
                {
                    b.HasOne("WPFUserInterface.Models.Instructor", null)
                        .WithMany("Subjects")
                        .HasForeignKey("InstructorID");
                });
#pragma warning restore 612, 618
        }
    }
}
