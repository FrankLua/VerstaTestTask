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

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAll()
        {
           return await _orderRepository.GetAll();
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
