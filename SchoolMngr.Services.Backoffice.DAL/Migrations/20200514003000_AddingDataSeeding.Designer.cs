﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolMngr.BackOffice.DAL;

namespace SchoolMngr.BackOffice.DAL.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20200514003000_AddingDataSeeding")]
    partial class AddingDataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Assingment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AssingmentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndsTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartsTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Assingments","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClassID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssingmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClosesDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("EnrolledQty")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartsDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssingmentId");

                    b.HasIndex("RoomId");

                    b.ToTable("Classes","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("GradeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Grades","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClassRoomID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Capacity")
                        .HasColumnType("smallint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("HasNetworkConexion")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasScreenProjector")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ClassRooms","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubjectID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<short>("MaxAbsencesAllowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)3);

                    b.Property<short>("MinExamScoreRequired")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)6);

                    b.Property<int?>("RequiredId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("RequiredId");

                    b.ToTable("Subjects","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("TeacherID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("IdentityUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers","BO");
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Assingment", b =>
                {
                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Subject", "Subject")
                        .WithMany("Assingments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Teacher", "Teacher")
                        .WithMany("Assingments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Class", b =>
                {
                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Assingment", "Assingment")
                        .WithMany()
                        .HasForeignKey("AssingmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolMngr.BackOffice.Model.Entities.Subject", b =>
                {
                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMngr.BackOffice.Model.Entities.Subject", "Required")
                        .WithMany()
                        .HasForeignKey("RequiredId");
                });
#pragma warning restore 612, 618
        }
    }
}
