using AngularJS.SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS.SportsStore.Domain.Abstract
{
    public interface IDbFactory : IDisposable
    {
        EFDbContext Init();
    }
}
