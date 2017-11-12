using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Models
{
    public class QuotesContext : DbContext
    {
        public DbSet<Quotes> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=midax-a-minjs-rds.cuxi7qfyfqir.us-west-2.rds.amazonaws.com;User Id=mikie;Password=mi4;Database=test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Quote)
                    .HasColumnName("quote")
                    .HasColumnType("varchar(200)");
            });
        }
    }
}