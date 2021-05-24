using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentExchange.Business.Models;

namespace PaymentExchange.Data.Mappings
{
   public class InvoiceMapping : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

    
            //    .HasColumnType("varchar(200)");


            // 1 : N => Invoice : InvoiceLine

            //builder.HasMany(f => f.InvoiceLines)
            //    .WithOne(p => p.Invoice)
            //    .HasForeignKey(p => p.InvoiceId);

            //builder.ToTable("Invoices");
        }
    }
}
