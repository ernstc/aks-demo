using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DemoWebApp.Models
{
    public class DemoDbContext : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }


        public DemoDbContext(DbContextOptions<DemoDbContext> options)
           : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            foreach (var item in optionsBuilder.Options.Extensions)
            {
                if (item is RelationalOptionsExtension extension)
                {
                    optionsBuilder.UseSqlServer(extension.ConnectionString);
                    break;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Map_Country(modelBuilder);
            Map_Region(modelBuilder);
        }


        private void Map_Country(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "dbo");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }


        private void Map_Region(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "dbo");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
