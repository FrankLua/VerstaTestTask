
using Application.Services.Interfaces;
using Infrastructure.Repositories.Implementation;
using Application.Services.Implementation;
using Infrastructure.Repositories.Interfaces;


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
       
        }
    }

}
