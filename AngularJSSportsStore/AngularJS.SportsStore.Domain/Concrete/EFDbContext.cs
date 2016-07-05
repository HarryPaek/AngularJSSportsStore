using AngularJS.SportsStore.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AngularJS.SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public IDbSet<Product> ProductSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
