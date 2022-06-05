﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz_Management_System.Data;

#nullable disable

namespace Quiz_Management_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220604082651_addModels")]
    partial class addModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("coursesId")
                        .HasColumnType("int");

                    b.Property<int>("studentsId")
                        .HasColumnType("int");

                    b.HasKey("coursesId", "studentsId");

                    b.HasIndex("studentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Choice", b =>
                {
                    b.Property<string>("choice")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("choice");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("teacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("teacherId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Link", b =>
                {
                    b.Property<string>("link")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("QuizMaterialId")
                        .HasColumnType("int");

                    b.HasKey("link");

                    b.HasIndex("QuizMaterialId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isMCQ")
                        .HasColumnType("bit");

                    b.Property<int>("marks")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("QuizMaterial")
                        .HasColumnType("int");

                    b.Property<int>("Weightage")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("QuizMaterial");

                    b.ToTable("quizzes");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.QuizMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizMaterials");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Report", b =>
                {
                    b.Property<int>("ReportNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportNumber"), 1L, 1);

                    b.Property<int>("IssuedById")
                        .HasColumnType("int");

                    b.Property<int>("IssuedToId")
                        .HasColumnType("int");

                    b.HasKey("ReportNumber");

                    b.HasIndex("IssuedById");

                    b.HasIndex("IssuedToId");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz_Management_System.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("studentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Choice", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Question", null)
                        .WithMany("choices")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Course", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Teacher", "teacher")
                        .WithMany("Courses")
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Link", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.QuizMaterial", null)
                        .WithMany("links")
                        .HasForeignKey("QuizMaterialId");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Question", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Quiz", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Course", "Course")
                        .WithMany("quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz_Management_System.Models.QuizMaterial", "quizMaterial")
                        .WithMany()
                        .HasForeignKey("QuizMaterial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("quizMaterial");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Report", b =>
                {
                    b.HasOne("Quiz_Management_System.Models.Student", "IssuedBy")
                        .WithMany()
                        .HasForeignKey("IssuedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz_Management_System.Models.Teacher", "IssuedTo")
                        .WithMany()
                        .HasForeignKey("IssuedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssuedBy");

                    b.Navigation("IssuedTo");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Course", b =>
                {
                    b.Navigation("quizzes");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Question", b =>
                {
                    b.Navigation("choices");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.QuizMaterial", b =>
                {
                    b.Navigation("links");
                });

            modelBuilder.Entity("Quiz_Management_System.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}