using Infrastructure.Cache.Interfaces;
using Application.Services.Interfaces;
using Infrastructure.Repositories.Implementation;
using Application.Services.Implementation;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Cache.Implementation;

namespace StepMaster.Initialization.Scope
{
    public static class ScopeBuilder
    {

        public static void InitializerService(IServiceCollection service)
        {                   
            service.AddScoped<IOrderService, OrderService>();        
        }
        public static void InitializerRepsitories(IServiceCollection service)
        {
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IMy_Cache, My_Cache_Implementate>();
        }
    }

}
