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
    public class ComicBookMap : IEntityTypeConfiguration<ComicBook>
    {
        public void Configure(EntityTypeBuilder<ComicBook> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                ;

            builder.Property(x => x.Title)
                .IsRequired()
                ;

            builder.Property(x => x.Description)
                .IsRequired()
                ;

            builder.Property(x => x.PublicationDate)
                .IsRequired()
                ;

            builder.Property(x => x.Price)
                .HasPrecision(10, 2)
                .IsRequired()
                ;

            builder.Property(x => x.Author)
                .IsRequired()
                ;

            builder.Property(x => x.Stock)
                .IsRequired()
                ;


        }

        
    }
}
