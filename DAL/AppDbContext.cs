using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost, 5020;Initial Catalog=FluentApi;Persist Security Info=True;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;");
                // optionsBuilder.UseSqlServer("Data Source=DESKTOP-K1T5VK8\\SQLEXPRESS;Initial Catalog=WebApiTest;Integrated Security=True; TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());   
        }
    }
}
