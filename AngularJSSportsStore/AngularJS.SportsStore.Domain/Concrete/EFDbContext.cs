using AngularJS.SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
