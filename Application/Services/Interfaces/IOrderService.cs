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
        Task<int> GetCountPages();
        Task<List<Order>> GetByPagination(int pageNumber);

        Task<Order> GetOne(int idOrder);

        Task<int> SetOne(Order newOrder);

        Task<int> DeleteOne(int idOrder);
    }
}
