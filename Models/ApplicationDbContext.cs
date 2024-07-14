﻿using Microsoft.EntityFrameworkCore;

namespace ATMWithdrawalApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
       // public DbSet<DebtPayments> DebtPayments { get; set; }
       // public DbSet<Accounts> Accounts { get; set; }
        public DbSet<CustomerRelation> CustomerRelations { get; set; }
        public DbSet<CustomerJob> CustomerJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          /*  modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedNever();
          */
          /*  modelBuilder.Entity<Accounts>()
                .HasKey(a => a.ID_Account);
            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.ID_Customer);

            modelBuilder.Entity<DebtPayments>()
                .HasKey(d => d.PaymentId);
            modelBuilder.Entity<DebtPayments>()
                .HasOne(d => d.Customer)
                .WithMany(c => c.DebtPayments)
                .HasForeignKey(d => d.ID_Customer);
          */
           /* modelBuilder.Entity<CustomerJob>()
                .HasKey(j => j.Id);
            modelBuilder.Entity<CustomerJob>()
                .HasOne(j => j.Customer)
              //  .WithMany(c => c.CustomerJobs)
               // .HasForeignKey(j => j.CustomerId);

            modelBuilder.Entity<CustomerRelation>()
                .HasKey(r => r.Id); // Alan adı düzeltildi
            modelBuilder.Entity<CustomerRelation>()
                .HasOne(r => r.Customer)
               // .WithMany(c => c.CustomerRelations)
                //.HasForeignKey(r => r.CustomerId);

            // Decimal alanlar için store type tanımlamaları
            modelBuilder.Entity<Customer>()
                .Property(c => c.NetIncomeAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CustomerJob>()
                .Property(j => j.Salary)
                .HasColumnType("decimal(18,2)");

           /* modelBuilder.Entity<DebtPayments>()
                .Property(d => d.Amount)
                .HasColumnType("decimal(18,2)");*/
        }
    }
}
