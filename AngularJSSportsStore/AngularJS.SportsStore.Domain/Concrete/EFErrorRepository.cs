using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.Domain.Entities;

namespace AngularJS.SportsStore.Domain.Concrete
{
    public class EFErrorRepository : IErrorRepository
    {
        private readonly IDbFactory dbFactory;
        private EFDbContext dbContext;

        public EFErrorRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public EFDbContext DbContext {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Save(Error error)
        {
            if (error.ID == 0)
                DbContext.ErrorSet.Add(error);
        }
    }
}
