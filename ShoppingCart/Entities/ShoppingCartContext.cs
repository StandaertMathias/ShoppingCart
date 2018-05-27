using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoppingCart.Entities
{
    public partial class ShoppingCartContext : DbContext
    {
        public virtual DbSet<Cart> Cart { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=MVC_oefeningenreeks2;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Naam);

                entity.Property(e => e.Naam)
                    .HasMaxLength(30)
                    .ValueGeneratedNever();
            });
        }
    }
}
