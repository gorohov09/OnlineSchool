﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineSchool.Infrastructure.Persistence;

#nullable disable

namespace OnlineSchool.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230225100745_AddTime_InformationAdmission")]
    partial class AddTime_InformationAdmission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineSchool.Domain.Course.CourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountTasks")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.LessonEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.ModuleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.InformationAdmission.InformationAdmissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountCompletedTasks")
                        .HasColumnType("int");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdmission")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("InformationAdmission", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.Student.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.StudentTaskInformation.StudentTaskInformationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountAttempts")
                        .HasColumnType("int");

                    b.Property<bool>("IsSolve")
                        .HasColumnType("bit");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeLastAttempt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TaskId");

                    b.ToTable("StudentTaskInformation", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.LessonEntity", b =>
                {
                    b.HasOne("OnlineSchool.Domain.Course.Entities.ModuleEntity", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.ModuleEntity", b =>
                {
                    b.HasOne("OnlineSchool.Domain.Course.CourseEntity", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.TaskEntity", b =>
                {
                    b.HasOne("OnlineSchool.Domain.Course.Entities.LessonEntity", "Lesson")
                        .WithMany("Tasks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("OnlineSchool.Domain.InformationAdmission.InformationAdmissionEntity", b =>
                {
                    b.HasOne("OnlineSchool.Domain.Course.CourseEntity", "Course")
                        .WithMany("InformationAdmissions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineSchool.Domain.Student.StudentEntity", "Student")
                        .WithMany("InformationAdmissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OnlineSchool.Domain.StudentTaskInformation.StudentTaskInformationEntity", b =>
                {
                    b.HasOne("OnlineSchool.Domain.Student.StudentEntity", "Student")
                        .WithMany("Tasks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineSchool.Domain.Course.Entities.TaskEntity", "Task")
                        .WithMany("Students")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.CourseEntity", b =>
                {
                    b.Navigation("InformationAdmissions");

                    b.Navigation("Modules");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.LessonEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.ModuleEntity", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Course.Entities.TaskEntity", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("OnlineSchool.Domain.Student.StudentEntity", b =>
                {
                    b.Navigation("InformationAdmissions");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
