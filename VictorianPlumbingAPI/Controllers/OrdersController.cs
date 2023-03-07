using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VictorianPlumbingAPI.Model;

namespace VictorianPlumbingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems).ThenInclude(o => o.Product)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            ModelState.Clear();
            TryValidateModel(order);

            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();
                order.Customer.Id = Guid.NewGuid();

                if (order.OrderItems.Any())
                {
                    foreach (var item in order.OrderItems)
                    {
                        item.Id = Guid.NewGuid();
                        item.Product.Id = Guid.NewGuid();
                    }
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetOrders",  order);
        }
    }
}
