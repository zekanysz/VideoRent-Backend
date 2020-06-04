using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRent.Models
{
    public class MovieRentContext : DbContext
    {
        public MovieRentContext(DbContextOptions<MovieRentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Customer>().ToTable("Customers")
            //    .HasKey(x => x.CustomerId);

            var converter = new EnumToStringConverter<Gender>();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Gender)
                .HasConversion(converter);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
