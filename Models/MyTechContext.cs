using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Retfeet.API.Models
{
    public partial class MyTechContext : DbContext
    {
        public MyTechContext()
        {
        }

        public MyTechContext(DbContextOptions<MyTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }
        public virtual DbSet<Usermissions> Usermissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyTech;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Missions>(entity =>
            {
                entity.HasKey(e => e.MissionId)
                    .HasName("PK__missions__B3CFE5DB57455778");

                entity.ToTable("missions");

                entity.Property(e => e.MissionId)
                    .HasColumnName("missionId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientAdress)
                    .HasColumnName("clientAdress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber).HasColumnName("clientNumber");
            });

            modelBuilder.Entity<Operators>(entity =>
            {
                entity.HasKey(e => e.OperatorId)
                    .HasName("PK__operator__97012A33375A9EEB");

                entity.ToTable("operators");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operatorId")
                    .ValueGeneratedNever();

                entity.Property(e => e.OperatorName)
                    .IsRequired()
                    .HasColumnName("operatorName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usermissions>(entity =>
            {
                entity.HasKey(e => e.UsermissionId)
                    .HasName("PK__usermiss__A13717A68FC77739");

                entity.ToTable("usermissions");

                entity.Property(e => e.UsermissionId)
                    .HasColumnName("usermissionId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.MissionId).HasColumnName("missionId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Usermissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usermissi__missi__33D4B598");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usermissions)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usermissi__useri__32E0915F");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__CB9A1CFF448BE868");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperatorId).HasColumnName("operatorId");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__operatorI__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
