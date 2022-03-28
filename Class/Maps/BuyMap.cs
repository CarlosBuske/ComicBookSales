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
    public class BuyMap : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                ;

            builder.Property(x => x.IdUser)
                .IsRequired()
                ;

            builder.Property(x => x.TotalValue)
                .HasPrecision(10, 2)
                .IsRequired()
                ;

            builder.Property(x => x.Date)
                .IsRequired()
                ;

        }
    }
}
