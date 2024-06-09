using API.FurnitureStore.Data;
using API.FurnitureStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly APIFurnitureStoreContext _context;
        public OrdersController(APIFurnitureStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.ID == id);
            if (order == null) return NotFound();

            return Ok(order);   
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            if (order == null) return NotFound();
            if (order.OrderDetails == null) return BadRequest("Order should have at least one details");

            await _context.Orders.AddAsync(order);
            await _context.OrderDetails.AddRangeAsync(order.OrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post", order.ID, order);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            if (order == null) return NotFound();
            if (order.ID <= 0) return NotFound();

            var existingOrder = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.ID == o.ID);
            if (existingOrder == null) return NotFound();

            existingOrder.orderNumber = order.orderNumber;
            existingOrder.orderDate = order.orderDate;
            existingOrder.deliveryDate = order.deliveryDate;
            existingOrder.clientID = order.clientID;

            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);

            _context.Orders.Update(existingOrder);
            _context.OrderDetails.AddRange(order.OrderDetails);

            await _context.SaveChangesAsync();

            return NoContent();


        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Order order)
        {
            if (order == null) return NotFound();
            var existingOrder = await _context.Orders.Include(o =>o.OrderDetails).FirstOrDefaultAsync(o =>o.ID == order.ID);
            if (existingOrder == null) return NotFound();

            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
            _context.Orders.Remove(existingOrder);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
