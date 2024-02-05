using E_commerceAPi.Domain.Entities;
using E_commerceAPi.Domain.Entities.Cross;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;

namespace E_commerceAPi.Domain
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Report> Course_Reports { get; set; }
        public DbSet<User_Role_Cross> User_Role_Crosses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=7286;Port=5432;Database=5432_eticaret;Username=Hesen;Password=uni;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
