using orion.Configuration;
using orion.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace orion.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class orionDbContextFactory : IDesignTimeDbContextFactory<orionDbContext>
    {
        public orionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<orionDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(orionConsts.ConnectionStringName)
            );

            return new orionDbContext(builder.Options);
        }
    }
}