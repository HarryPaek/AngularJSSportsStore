using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.Domain.Infrastructure;

namespace AngularJS.SportsStore.Domain.Concrete
{
    public class DbFactory : Disposable, IDbFactory
    {
        EFDbContext dbContext;

        public EFDbContext Init()
        {
            return dbContext ?? (dbContext = new EFDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
