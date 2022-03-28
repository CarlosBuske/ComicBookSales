using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.Context
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ComicBook> ComicBook { get; set; }
        public virtual DbSet<Buy> Buy { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<PurchaseItems> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        } 
    }
}
