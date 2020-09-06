using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PQS.FSChallenge.Business
{
    public partial class PQSChallengeContext : DbContext
    {
        public PQSChallengeContext()
        {
        }

        public PQSChallengeContext(DbContextOptions<PQSChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersInfo> OrdersInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SM8SANU\\SQLEXPRESS;Database=PQS Challenge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK__ORDER_IT__57ED0680292E68A2")
                    .IsClustered(false);

                entity.ToTable("ORDER_ITEMS");

                entity.HasIndex(e => e.OrderId)
                    .IsClustered();

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(32, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ITEMS_ORDERS");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__ORDERS__C3905BCF4EE3B81E");

                entity.ToTable("ORDERS");

                entity.HasIndex(e => e.OrderStatus)
                    .HasName("IX_ORDER_Status");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrdersInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vORDERS_INFO");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Qitems).HasColumnName("QItems");

                entity.Property(e => e.Total).HasColumnType("numeric(38, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
