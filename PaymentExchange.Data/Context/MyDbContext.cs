using Microsoft.EntityFrameworkCore;
using PaymentExchange.Business.Models;
using FluentValidation;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentExchange.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            modelBuilder.Entity<Invoice>().Property(Invoices => Invoices.ClientPayment).HasPrecision(12, 2);
            modelBuilder.Entity<Invoice>().Property(Invoices => Invoices.InvoiceTotalEarnings).HasPrecision(12, 2);
            modelBuilder.Entity<Invoice>().Property(Invoices => Invoices.TotalMoneyDeduction).HasPrecision(12, 2);
            modelBuilder.Entity<InvoiceLine>().Property(InvoiceLines => InvoiceLines.ClientDeduction).HasPrecision(12, 2);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("PayDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("PayDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("PayDate").IsModified = false;
                }
            }



            return base.SaveChangesAsync(cancellationToken);

        }

      

    }
}