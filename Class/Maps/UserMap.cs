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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                ;

            builder.Property(x => x.Name)
                .IsRequired()
                ;

            builder.Property(x => x.Email)
                .IsRequired()
                ;

            builder.Property(x => x.Password)
                .IsRequired()
                ;

            builder.Property(x => x.IdUserType)
                .IsRequired()
                ;

            builder.HasOne(x => x.UserType)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.IdUserType)
                ;
        }
    }
}
