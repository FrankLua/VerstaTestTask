using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();

        Task<Order> GetOne(int idOrder);

        Task<int> SetOne(Order newOrder);
    }
}
