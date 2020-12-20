using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Npgsql;

namespace HealthCloud.Web.Models.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(p => p.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=anarchynet;Username=postgres;Password=password");
            optionsBuilder.UseNpgsql("Host=ec2-52-208-175-161.eu-west-1.compute.amazonaws.com;Port=5432;Database=da6q4qa1ni7q7h;Username=borqtblejwcpat;Password=48af36f4ff45d206782c0a084e0671c8906f14ed5cb16b85aa4d515ec979e648;Pooling=True;SSL Mode=Require;TrustServerCertificate=True;");

        }
    }
}
