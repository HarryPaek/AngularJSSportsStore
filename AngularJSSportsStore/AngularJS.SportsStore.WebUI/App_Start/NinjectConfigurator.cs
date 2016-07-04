using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.Domain.Concrete;
using AngularJS.SportsStore.Domain.Infrastructure;
using Ninject;
using Ninject.Web.Common;

namespace AngularJS.SportsStore.WebUI.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            container.Bind<IDbFactory>().To<DbFactory>().InRequestScope();
            container.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            container.Bind<IProductRepository>().To<EFProductRepository>().InRequestScope();
            container.Bind<IErrorRepository>().To<EFErrorRepository>().InRequestScope();
        }
    }
}