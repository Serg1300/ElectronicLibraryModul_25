using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary
{
    public class AppContext : DbContext
    {
        // Объекты 
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1CECV0T\SQLEXPRESS01;Database=EFlibrary;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable(t => t.HasCheckConstraint("GenreBook", "GenreBook in ('роман','повесть', 'драма', 'комедия', 'трагикомедия', 'рассказ')"));
        }
    }
}
