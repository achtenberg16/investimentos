using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using infrastructure.Entities;

namespace infrastructure.Context
{
    public partial class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AssetsPortfolio> AssetsPortfolios { get; set; } = null!;
        public virtual DbSet<DepositWithdrawal> DepositWithdrawals { get; set; } = null!;
        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
        public virtual DbSet<Ticker> Tickers { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=investimentos;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance)
                    .HasPrecision(10, 2)
                    .HasColumnName("balance");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts_user_id_fkey");
            });

            modelBuilder.Entity<AssetsPortfolio>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TickerId })
                    .HasName("assets_portfolio_pkey");

                entity.ToTable("assets_portfolio");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.TickerId).HasColumnName("ticker_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Ticker)
                    .WithMany(p => p.AssetsPortfolios)
                    .HasForeignKey(d => d.TickerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_portfolio_ticker_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssetsPortfolios)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_portfolio_user_id_fkey");
            });

            modelBuilder.Entity<DepositWithdrawal>(entity =>
            {
                entity.ToTable("deposit_withdrawal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Value)
                    .HasPrecision(10, 2)
                    .HasColumnName("value");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.DepositWithdrawals)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deposit_withdrawal_account_id_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DepositWithdrawals)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("deposit_withdrawal_type_id_fkey");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TickerId).HasColumnName("ticker_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("unit_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Ticker)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.TickerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operations_ticker_id_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operations_type_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operations_user_id_fkey");
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("operation_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Ticker>(entity =>
            {
                entity.ToTable("tickers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Ticker1)
                    .HasMaxLength(6)
                    .HasColumnName("ticker");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("unit_price");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
