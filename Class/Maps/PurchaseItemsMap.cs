using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Maps
{
    public class PurchaseItemsMap : IEntityTypeConfiguration<PurchaseItems>
    {
        public void Configure(EntityTypeBuilder<PurchaseItems> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                ;

            builder.Property(x => x.IdComicBook)
                .IsRequired()
                ;

            builder.Property(x => x.IdBuy)
                .IsRequired()
                ;

            builder.Property(x => x.UnitValue)
                .HasPrecision(10, 2)
                .IsRequired()
                ;

            builder.Property(x => x.Quantity)
                .IsRequired()
                ;

            builder.HasOne(x => x.comicbook)
                .WithMany(x => x.PurchaseItems)
                .HasForeignKey(x => x.IdComicBook)
                ;

            builder.HasOne(x => x.buy)
                .WithMany(x => x.PurchaseItems)
                .HasForeignKey(x => x.IdBuy)
                ;

            
        }
    }
}
