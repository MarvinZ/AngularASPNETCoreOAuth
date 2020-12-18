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

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupStatus> GroupStatuses { get; set; }
        public virtual DbSet<GroupStudent> GroupStudents { get; set; }
        public virtual DbSet<GroupTeacher> GroupTeachers { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<PadronCompleto> PadronCompletos { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
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
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.ActivityDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__Activi__4E1E9780");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activity__Client__4D2A7347");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Activity__GroupI__4C364F0E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Activity__Studen__4B422AD5");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("ActivityType");

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

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Document__Client__308E3499");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Document__GroupI__2F9A1060");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Document__Studen__2EA5EC27");
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

                entity.Property(e => e.MaxDate).HasColumnType("datetime");

                entity.Property(e => e.MinDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__ClientId__0E391C95");

                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__CycleId__0C50D423");

                entity.HasOne(d => d.GroupStatus)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__GroupStat__0D44F85C");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Group__LevelId__0B5CAFEA");
            });

            modelBuilder.Entity<GroupStatus>(entity =>
            {
                entity.ToTable("GroupStatus");

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
                    .HasConstraintName("FK__GroupStud__Group__1209AD79");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Stude__11158940");
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
                    .HasConstraintName("FK__GroupTeac__Group__15DA3E5D");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.GroupTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupTeac__Teach__14E61A24");
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

            modelBuilder.Entity<PadronCompleto>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("PADRON_COMPLETO");

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Apellido2).HasMaxLength(50);

                entity.Property(e => e.Column4).HasColumnName("column4");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
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

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Parent__ClientId__7C1A6C5A");
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
                    .HasConstraintName("FK__Payment__ParentI__1975C517");

                entity.HasOne(d => d.PaymentRequest)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Payment__1A69E950");
            });

            modelBuilder.Entity<PaymentRequest>(entity =>
            {
                entity.ToTable("PaymentRequest");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeactivateDatetime).HasColumnType("datetime");

                entity.Property(e => e.DeactivateUser).HasMaxLength(100);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.LastModificationDatetime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(100);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PaymentRequests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentRe__Clien__14B10FFA");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.PaymentRequests)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentRe__Payme__15A53433");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.PaymentRequests)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentRe__Payme__1699586C");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PaymentRequests)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaymentRe__Stude__13BCEBC1");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

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

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

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

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__ClientI__793DFFAF");
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
                    .HasConstraintName("FK__StudentPa__Paren__7EF6D905");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentParents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentPa__Stude__7FEAFD3E");
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

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teacher__ClientI__02C769E9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
