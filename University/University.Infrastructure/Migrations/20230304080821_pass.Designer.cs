﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Infrastructure.Configurations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230304080821_pass")]
    partial class pass
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("University.Core.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseGp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("bit");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("University.Core.Models.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldId"));

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxUnit")
                        .HasMaxLength(24)
                        .HasColumnType("int");

                    b.Property<int>("MinUnit")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FieldId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("University.Core.Models.SelectUnit", b =>
                {
                    b.Property<int>("SelectUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SelectUnitId"));

                    b.Property<DateTime>("Ended")
                        .HasColumnType("datetime2");

                    b.Property<int>("Limit")
                        .HasColumnType("int");

                    b.Property<DateTime>("Started")
                        .HasColumnType("datetime2");

                    b.HasKey("SelectUnitId");

                    b.ToTable("SelectUnits");
                });

            modelBuilder.Entity("University.Core.Models.SelectUnitCourse", b =>
                {
                    b.Property<int>("SelectUnitCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SelectUnitCourseId"));

                    b.Property<int>("Capability")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SelectUnitId")
                        .HasColumnType("int");

                    b.HasKey("SelectUnitCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SelectUnitId");

                    b.ToTable("SelectUnitCourses");
                });

            modelBuilder.Entity("University.Core.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("BirthDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalCode")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("FieldId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("University.Core.Models.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("University.Core.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("LastDiploma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherBirthDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherNationalCode")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("University.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("UserName")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("University.Core.Models.Course", b =>
                {
                    b.HasOne("University.Core.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("University.Core.Models.SelectUnitCourse", b =>
                {
                    b.HasOne("University.Core.Models.Course", "Course")
                        .WithMany("SelectUnitCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Core.Models.SelectUnit", "SelectUnit")
                        .WithMany("SelectUnitCourses")
                        .HasForeignKey("SelectUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("SelectUnit");
                });

            modelBuilder.Entity("University.Core.Models.Student", b =>
                {
                    b.HasOne("University.Core.Models.Field", "Field")
                        .WithMany("Students")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");
                });

            modelBuilder.Entity("University.Core.Models.StudentCourse", b =>
                {
                    b.HasOne("University.Core.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("University.Core.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("University.Core.Models.User", b =>
                {
                    b.HasOne("University.Core.Models.Student", "Student")
                        .WithMany("Users")
                        .HasForeignKey("StudentId");

                    b.HasOne("University.Core.Models.Teacher", "Teacher")
                        .WithMany("Users")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("University.Core.Models.Course", b =>
                {
                    b.Navigation("SelectUnitCourses");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("University.Core.Models.Field", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("University.Core.Models.SelectUnit", b =>
                {
                    b.Navigation("SelectUnitCourses");
                });

            modelBuilder.Entity("University.Core.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("University.Core.Models.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}