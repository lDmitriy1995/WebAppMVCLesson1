using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ATR.API.Models;

namespace ATR.API.Data
{
    public partial class WebAppMVCLesson1DbContext : DbContext
    {
        public WebAppMVCLesson1DbContext()
        {
        }

        public WebAppMVCLesson1DbContext(DbContextOptions<WebAppMVCLesson1DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasePick> BasePicks { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<JobPosition> JobPositions { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<PageStatistic> PageStatistics { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomProperty> RoomProperties { get; set; } = null!;
        public virtual DbSet<TeamWork> TeamWorks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DESKTOP-QQR48TL;Database=HotelAtr;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasePick>(entity =>
            {
                entity.HasKey(e => e.Carruselld);

                entity.ToTable("BasePick");

                entity.Property(e => e.Title).HasMaxLength(230);
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Ip)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Level).HasMaxLength(128);

                entity.Property(e => e.Properties).HasColumnType("xml");

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<PageStatistic>(entity =>
            {
                entity.HasKey(e => e.PageStatisticsId);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Path).HasMaxLength(500);

                entity.Property(e => e.PathBase).HasMaxLength(500);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                //entity.HasIndex(e => e.CategoryId, "IX_Rooms_CategoryId");

                //entity.Property(e => e.MainPicturePath).HasDefaultValueSql("(N'')");

                //entity.HasOne(d => d.Category)
                //    .WithMany(p => p.Rooms)
                //    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<RoomProperty>(entity =>
            {
                entity.HasMany(d => d.RoomsRooms)
                    .WithMany(p => p.RoomPropertiesRoomProperties)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomRoomProperty",
                        l => l.HasOne<Room>().WithMany().HasForeignKey("RoomsRoomId"),
                        r => r.HasOne<RoomProperty>().WithMany().HasForeignKey("RoomPropertiesRoomPropertyId"),
                        j =>
                        {
                            j.HasKey("RoomPropertiesRoomPropertyId", "RoomsRoomId");

                            j.ToTable("RoomRoomProperty");

                            j.HasIndex(new[] { "RoomsRoomId" }, "IX_RoomRoomProperty_RoomsRoomId");
                        });
            });

            modelBuilder.Entity<TeamWork>(entity =>
            {
                entity.HasIndex(e => e.JobPositionId, "IX_TeamWorks_JobPositionId");

                entity.Property(e => e.AboutWork).HasMaxLength(1024);

                entity.Property(e => e.Autor).HasMaxLength(250);

                entity.Property(e => e.FaceBook).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Instagram).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.LinkedIn).HasMaxLength(250);

                entity.Property(e => e.ModdleName).HasMaxLength(250);

                entity.Property(e => e.Photo).HasMaxLength(500);

                entity.HasOne(d => d.JobPosition)
                    .WithMany(p => p.TeamWorks)
                    .HasForeignKey(d => d.JobPositionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
