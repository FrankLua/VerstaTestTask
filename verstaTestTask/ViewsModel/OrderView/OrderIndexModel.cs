using Domain.Models;

namespace verstaTestTask.ViewsModel.View
{
    public class OrderIndexModel
    {
        public int CountPages { get; set; }

        public int NumberActualPage { get; set; }

        public List<Order> Orders { get; set; }
    }
}
