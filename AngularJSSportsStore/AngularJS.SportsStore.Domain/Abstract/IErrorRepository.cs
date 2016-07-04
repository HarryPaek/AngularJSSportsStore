using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.SportsStore.Domain.Entities;

namespace AngularJS.SportsStore.Domain.Abstract
{
    public interface IErrorRepository
    {
        void Save(Error error);
    }
}
