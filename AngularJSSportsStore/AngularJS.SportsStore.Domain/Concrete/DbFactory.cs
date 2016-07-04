using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
