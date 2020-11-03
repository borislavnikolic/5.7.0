using System;
using System.Threading.Tasks;
using Abp.TestBase;
using orion.EntityFrameworkCore;
using orion.Tests.TestDatas;

namespace orion.Tests
{
    public class orionTestBase : AbpIntegratedTestBase<orionTestModule>
    {
        public orionTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<orionDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<orionDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<orionDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<orionDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<orionDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<orionDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<orionDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<orionDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
