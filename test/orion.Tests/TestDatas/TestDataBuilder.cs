using orion.EntityFrameworkCore;

namespace orion.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly orionDbContext _context;

        public TestDataBuilder(orionDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}