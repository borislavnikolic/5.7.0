using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using orion.Model;

namespace orion.EntityFrameworkCore
{
    public class orionDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Package> Packages { get; set; }

        public DbSet<Concract> Concracts { get; set; }

        public DbSet<PackageXConcract> PackageXConcracts { get; set; }

        public DbSet<History> Histories { get; set; }
        public orionDbContext(DbContextOptions<orionDbContext> options) 
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackageXConcract>().HasAlternateKey(c => new{ c.PackageID, c.ConcractID }).HasName("IX_MultipleColumns");


        }
       
    }
}
