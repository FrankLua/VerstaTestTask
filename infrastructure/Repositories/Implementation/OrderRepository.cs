using Domain.Models;

using Infrastructure.EntityFrameWork;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
    
        private ILogger<OrderRepository> _logger;
        public OrderRepository(OrderContext context,  ILogger<OrderRepository> logger)
        {
            _context = context;
          
            _logger = logger;
        }

        public async Task<int> DeleteOne(int id)
        {
            try
            {
                var order =  await _context.Orders.Where(o => o.Id == id).FirstAsync();
                _context.Orders.Remove(order);
                await  _context.SaveChangesAsync();
                return id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new HttpRequestException("GetAllOrder", null, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<List<Order>> GetOrdersOnPage(int pageNumber, int maxEntity)
        {
            try
            {
                
                   var  list = await _context.Orders.OrderBy(o => o.Id).Skip(pageNumber* maxEntity).Take(maxEntity).ToListAsync();                 
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

            try
            {
                var item = _context.Orders.Where(o => o.Id == id).FirstOrDefault();
                if (item == null)
                {
                    throw new HttpRequestException("ReadOne", null, System.Net.HttpStatusCode.NotFound);
                }
                   return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new HttpRequestException("GetAllOrder", null, System.Net.HttpStatusCode.InternalServerError);
            }
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

        public async Task<int> GetCountRows()
        {
            return await _context.Orders.CountAsync();
        }
    }
}
