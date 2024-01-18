using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly int _maxEntityOnPage = 8;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async  Task<int> DeleteOne(int idOrder)
        {
           return await _orderRepository.DeleteOne(idOrder);
        }

        public async Task<List<Order>> GetByPagination(int pageNumber)
        {
           return await _orderRepository.GetOrdersOnPage(pageNumber,_maxEntityOnPage);
        }

        public async Task<int> GetCountPages()
        {
            var test = await _orderRepository.GetCountRows();
            var countPage = (await _orderRepository.GetCountRows() / (float)_maxEntityOnPage);
            if(countPage != 0)
            {
                var result = (int)countPage + 1;
                return result;
            }
            return 0;
        }

        public async Task<Order> GetOne(int idOrder)
        {
            return await _orderRepository.ReadOne(idOrder);
        }

        public Task<int> SetOne(Order newOrder)
        {
           return _orderRepository.SetOne(newOrder);
        }
    }
}
