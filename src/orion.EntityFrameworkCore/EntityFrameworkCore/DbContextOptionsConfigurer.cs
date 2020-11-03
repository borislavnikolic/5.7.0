using Microsoft.EntityFrameworkCore;

namespace orion.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<orionDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for orionDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
