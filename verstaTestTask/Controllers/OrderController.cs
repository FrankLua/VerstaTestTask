using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using verstaTestTask.ViewsModel.View;

namespace verstaTestTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService = null)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index([FromQuery]int pageNumber)
        {
            var model = new OrderIndexModel
            {
                NumberActualPage = pageNumber,
                CountPages = await _orderService.GetCountPages(),
                Orders = await _orderService.GetByPagination(pageNumber)
            };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> SetOrder(Order newOrder)
        {            
            await _orderService.SetOne(newOrder);
            return Redirect("~/Order/Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOrder( int id)
        {
            await _orderService.DeleteOne(id);
            return Redirect("~/Order/Index");
        }


    }
}
