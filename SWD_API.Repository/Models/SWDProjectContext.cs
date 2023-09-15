using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SWD_API.Repository.Models
{
    public partial class SWDProjectContext : DbContext
    {
        public SWDProjectContext()
        {
        }

        public SWDProjectContext(DbContextOptions<SWDProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Intern> Interns { get; set; } = null!;
        public virtual DbSet<InternProjectMapping> InternProjectMappings { get; set; } = null!;
        public virtual DbSet<InternWorkShift> InternWorkShifts { get; set; } = null!;
        public virtual DbSet<InternshipSemester> InternshipSemesters { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamLeader> TeamLeaders { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;
        public virtual DbSet<WorkShift> WorkShifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:SWDProjectDatabase"];

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InternWorkShiftId).HasColumnName("InternWorkShift_Id");

                entity.HasOne(d => d.InternWorkShift)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.InternWorkShiftId)
                    .HasConstraintName("FK_Attendance_InternWorkShift");
            });

            modelBuilder.Entity<Intern>(entity =>
            {
                entity.ToTable("Intern");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.InternshipSemesterId).HasColumnName("InternshipSemester_Id");

                entity.Property(e => e.MajorId).HasColumnName("Major_Id");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");

                entity.Property(e => e.UniversityId).HasColumnName("University_Id");

                entity.HasOne(d => d.InternshipSemester)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.InternshipSemesterId)
                    .HasConstraintName("FK_Intern_InternshipSemester");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK_Intern_Major");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Intern_Team");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Interns)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_Intern_University");
            });

            modelBuilder.Entity<InternProjectMapping>(entity =>
            {
                entity.ToTable("InternProjectMapping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InternId).HasColumnName("Intern_Id");

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.InternProjectMappings)
                    .HasForeignKey(d => d.InternId)
                    .HasConstraintName("FK_InternProjectMapping_Intern");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.InternProjectMappings)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_InternProjectMapping_Project");
            });

            modelBuilder.Entity<InternWorkShift>(entity =>
            {
                entity.ToTable("InternWorkShift");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InternId).HasColumnName("Intern_Id");

                entity.Property(e => e.WorkShiftId).HasColumnName("WorkShift_Id");

                entity.HasOne(d => d.Intern)
                    .WithMany(p => p.InternWorkShifts)
                    .HasForeignKey(d => d.InternId)
                    .HasConstraintName("FK_InternWorkShift_Intern");

                entity.HasOne(d => d.WorkShift)
                    .WithMany(p => p.InternWorkShifts)
                    .HasForeignKey(d => d.WorkShiftId)
                    .HasConstraintName("FK_InternWorkShift_WorkShift");
            });

            modelBuilder.Entity<InternshipSemester>(entity =>
            {
                entity.ToTable("InternshipSemester");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TeamLeaderId).HasColumnName("TeamLeader_Id");

                entity.HasOne(d => d.TeamLeader)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamLeaderId)
                    .HasConstraintName("FK_Team_TeamLeader");
            });

            modelBuilder.Entity<TeamLeader>(entity =>
            {
                entity.ToTable("TeamLeader");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkShift>(entity =>
            {
                entity.ToTable("WorkShift");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
