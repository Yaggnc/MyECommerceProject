using Microsoft.Extensions.DependencyInjection;
using MyECommerce.BLL.Abstract;
using MyECommerce.BLL.Concrete;
using MyECommerce.Entity.Base;
using MyECommerce.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyECommerce.BLL
{
    public static class ServiceExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
