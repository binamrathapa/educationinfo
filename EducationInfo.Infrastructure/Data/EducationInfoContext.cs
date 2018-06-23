using System;
using EducationInfo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EducationInfo.Infrastructure
{
    public partial class EducationInfoContext : DbContext
    {
        
        public EducationInfoContext(DbContextOptions<EducationInfoContext> options)
            : base(options)
        {
            
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssignmentLocation).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Assignment_Batch");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Assignment_College");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Assignment_Semester");
            });

            modelBuilder.Entity<AssignmentSubmittedByStudent>(entity =>
            {
                entity.Property(e => e.ProjectLocation).IsUnicode(false);

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentSubmittedByStudent)
                    .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK_AssignmentSubmittedByStudent_Assignment");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AssignmentSubmittedByStudent)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_AssignmentSubmittedByStudent_Student");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<College>(entity =>
            {
                entity.Property(e => e.AffiliatedBy).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.University)
                    .WithMany(p => p.College)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_College_University");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<CoursesPerUniversity>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesPerUniversity)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CoursesPerUniversity_Course");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.CoursesPerUniversity)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CoursesPerUniversity_University");
            });

            modelBuilder.Entity<NoteDownloadInfo>(entity =>
            {
                entity.HasOne(d => d.Note)
                    .WithMany(p => p.NoteDownloadInfo)
                    .HasForeignKey(d => d.NoteId)
                .HasConstraintName("FK_NoteDownloadInfo_NoteDownloadInfo");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.NoteDownloadInfo)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_NoteDownloadInfo_Student");
            });

            modelBuilder.Entity<NoteInfo>(entity =>
            {
                entity.Property(e => e.NoteLocation).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.NoteInfo)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Note_Course");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.Cascade)
                 .HasConstraintName("FK_Student_Batch");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_Student_Semester");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Student_User");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<AssignmentSubmittedByStudent> AssignmentSubmittedByStudent { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<College> College { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CoursesPerUniversity> CoursesPerUniversity { get; set; }
        public virtual DbSet<NoteDownloadInfo> NoteDownloadInfo { get; set; }
        public virtual DbSet<NoteInfo> NoteInfo { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
