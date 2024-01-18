using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository:IBaseCRUD<Order>
    {
        Task<List<Order>> GetOrdersOnPage(int pageNumber,int maxEntity);

        Task<int> GetCountRows();
    }
}
