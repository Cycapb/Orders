using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Businesslogic;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Models;
using Ninject;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IOrderManager>().To<OrderManager>();
            _kernel.Bind<IRepository<Order>>().To<EntityRepository<Order>>();
            _kernel.Bind<IRepository<OrderDetail>>().To<EntityRepository<OrderDetail>>();
            _kernel.Bind<IRepository<Product>>().To<EntityRepository<Product>>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}