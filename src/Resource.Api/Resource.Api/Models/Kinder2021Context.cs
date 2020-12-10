using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Kinder2021Context : DbContext
    {
        public Kinder2021Context()
        {
        }

        public Kinder2021Context(DbContextOptions<Kinder2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupStudent> GroupStudents { get; set; }
        public virtual DbSet<GroupTeacher> GroupTeachers { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentParent> StudentParents { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Kinder2021;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.ToTable("Cycle");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.FileLocation)
                    .HasMaxLength(400)
                    .HasColumnName("fileLocation");

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Document__GroupI__489AC854");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Document__Studen__47A6A41B");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.GroupShortname).HasMaxLength(250);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__CycleId__2FCF1A8A");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__LevelId__2EDAF651");
            });

            modelBuilder.Entity<GroupStudent>(entity =>
            {
                entity.ToTable("GroupStudent");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Group__5BAD9CC8");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Stude__5AB9788F");
            });

            modelBuilder.Entity<GroupTeacher>(entity =>
            {
                entity.ToTable("GroupTeacher");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupTeachers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupTeac__Group__55F4C372");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.GroupTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupTeac__Teach__55009F39");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.LastName1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName2).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__ParentI__3864608B");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.LastName1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName2).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentParent>(entity =>
            {
                entity.ToTable("StudentParent");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.StudentParents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentPa__Paren__58D1301D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentParents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentPa__Stude__59C55456");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.LastName1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName2).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
