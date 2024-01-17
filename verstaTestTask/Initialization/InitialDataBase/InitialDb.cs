using Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;

namespace verstaTestTask.Initialization.InitialDataBase
{
    public class InitialDb
    {
        public static void StatrtDb(WebApplicationBuilder builder) 
        {
            var service = builder.Services;
            string connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            service.AddDbContext<OrderContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
