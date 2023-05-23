using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UsmanovBochkarev.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicDiscipline> AcademicDisciplines { get; set; }

    public virtual DbSet<AcademicPlan> AcademicPlans { get; set; }

    public virtual DbSet<AccessPermission> AccessPermissions { get; set; }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Cycle> Cycles { get; set; }

    public virtual DbSet<DisciplineinAcademicPlan> DisciplineinAcademicPlans { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostUser> PostUsers { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Сathedra> Сathedras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;User=root;DataBase=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicDiscipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FullNameOfDiscipline).HasMaxLength(45);
            entity.Property(e => e.ShortNameOfDiscipline).HasMaxLength(45);
        });

        modelBuilder.Entity<AcademicPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.NameAcademicPlan).HasMaxLength(45);
        });

        modelBuilder.Entity<AccessPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.PostId, "PostId_idx");

            entity.Property(e => e.Permission).HasMaxLength(45);

            entity.HasOne(d => d.Post).WithMany(p => p.AccessPermissions)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AccesPermissionPostId");
        });

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.SpecialityId, "Specialityid_idx");

            entity.Property(e => e.MiddleOfNameApplicants).HasMaxLength(45);
            entity.Property(e => e.NameApplicants).HasMaxLength(45);
            entity.Property(e => e.SurnameApplicants).HasMaxLength(45);

            entity.HasOne(d => d.Speciality).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SpecialityId");
        });

        modelBuilder.Entity<Cycle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AcademicPlan, "AcademicPlan_idx");

            entity.Property(e => e.NameCycle).HasMaxLength(45);

            entity.HasOne(d => d.AcademicPlanNavigation).WithMany(p => p.Cycles)
                .HasForeignKey(d => d.AcademicPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AcademicPlan");
        });

        modelBuilder.Entity<DisciplineinAcademicPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CycleId, "CycleId_idx");

            entity.HasIndex(e => e.AcademicDisciplineId, "DirectoryId_idx");

            entity.Property(e => e.NameDisciplineinAcademicPlan).HasMaxLength(45);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.AcademicDiscipline).WithMany(p => p.DisciplineinAcademicPlans)
                .HasForeignKey(d => d.AcademicDisciplineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AcademicDisciplineId");

            entity.HasOne(d => d.Cycle).WithMany(p => p.DisciplineinAcademicPlans)
                .HasForeignKey(d => d.CycleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AcademicCycleId");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.SpecialtyId, "SpecialtyId_idx");

            entity.HasIndex(e => e.UserIdCurator, "Userid_idx");

            entity.Property(e => e.UserIdCurator).HasColumnName("UserId(Curator)");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SpecialtyId");

            entity.HasOne(d => d.UserIdCuratorNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.UserIdCurator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Userid");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.DisciplinInAcademicPlanId, "DisciplinInAcademicPlanId_idx");

            entity.HasIndex(e => e.GroupId, "GroupId_idx");

            entity.HasIndex(e => e.OfficeId, "OfficeID_idx");

            entity.HasIndex(e => e.UserId, "UserId_idx");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Order).HasMaxLength(45);

            entity.HasOne(d => d.DisciplinInAcademicPlan).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.DisciplinInAcademicPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DisciplinInAcademicPlanId");

            entity.HasOne(d => d.Group).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupId");

            entity.HasOne(d => d.Office).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OfficeID");

            entity.HasOne(d => d.User).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LessonUserId");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.NameOffice).HasMaxLength(45);
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.StudentId, "StudentID_idx");

            entity.Property(e => e.MiddleOfNameParents).HasMaxLength(45);
            entity.Property(e => e.NameParents).HasMaxLength(45);
            entity.Property(e => e.SurnameParents).HasMaxLength(45);

            entity.HasOne(d => d.Student).WithMany(p => p.Parents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StudentID");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.NamePost).HasMaxLength(45);
        });

        modelBuilder.Entity<PostUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post-users");

            entity.HasIndex(e => e.PostId, "PostId_idx");

            entity.HasIndex(e => e.PostUserId, "PostUserId_idx");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PostId");

            entity.HasOne(d => d.PostUserNavigation).WithMany()
                .HasForeignKey(d => d.PostUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PostUserId");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CathedraId, "Cathedraid_idx");

            entity.Property(e => e.NameSpeciality).HasMaxLength(45);

            entity.HasOne(d => d.Cathedra).WithMany(p => p.Specialties)
                .HasForeignKey(d => d.CathedraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cathedraid");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.GroupsId, "GroupsId_idx");

            entity.HasIndex(e => e.SurnameStudents, "surname_UNIQUE").IsUnique();

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.MiddleOfNameStudents).HasMaxLength(45);
            entity.Property(e => e.NameStudents).HasMaxLength(45);
            entity.Property(e => e.SurnameStudents).HasMaxLength(45);

            entity.HasOne(d => d.Groups).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupsId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.LoginUser).HasMaxLength(45);
            entity.Property(e => e.MiddleName).HasMaxLength(45);
            entity.Property(e => e.NameUser).HasMaxLength(45);
            entity.Property(e => e.PasswordUser).HasMaxLength(45);
            entity.Property(e => e.SurnameUser).HasMaxLength(45);
        });

        modelBuilder.Entity<Сathedra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.NameCathedra).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
