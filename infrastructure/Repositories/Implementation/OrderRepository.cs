using Domain.Models;
using Infrastructure.EntityFrameWork;

using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Infrastructure.Cache.Interfaces;


namespace Infrastructure.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        private readonly IMy_Cache _cache;
        private ILogger<OrderRepository> _logger;
        private readonly string _keyListCache = "listOrders";
        private readonly string _keyOneCache = "order:";
       

        public OrderRepository(OrderContext context, IMy_Cache cache, ILogger<OrderRepository> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public Task<bool> DeleteOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAll()
        {
            try
            {
                var list = (List<Order>)_cache.GetObject(_keyListCache);
                if (list == null)
                {
                    list = await _context.Orders.OrderBy(o => o.Id).ToListAsync();
                    _cache.SetObject(_keyListCache, list, 10);
                }
                return list;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new HttpRequestException("GetAllOrder",null,System.Net.HttpStatusCode.InternalServerError);
            }
            
        }

        public async Task<Order> ReadOne(int id)
        {
            
            var item = (Order)_cache.GetObject(_keyOneCache+id);
            if(item == null)
            {
                try
                {
                    item = _context.Orders.Where(o => o.Id == id).FirstOrDefault();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    throw new HttpRequestException("GetAllOrder", null, System.Net.HttpStatusCode.InternalServerError);
                }
                if(item == null)
                {
                    throw new HttpRequestException("ReadOne", null, System.Net.HttpStatusCode.NotFound);
                }
                _cache.SetObject(_keyOneCache + id, item, 10);
            }
            return item;
        }

        public async Task<int> SetOne(Order newOrder)
        {
            try
            {
                if (newOrder.Id == default)
                {
                    _context.Entry(newOrder).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(newOrder).State = EntityState.Modified;
                    
                }
                _context.SaveChanges();
                return newOrder.Id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new HttpRequestException("SetOne", null, System.Net.HttpStatusCode.InternalServerError);
            }          
            

        }

        public Task<Order> UpdateOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
