using Lw.FchStore.Api.Panel.Request.OrderItem;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lw.FchStore.Api.Panel.Controllers
{
    [Route("panel/api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManage")]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemAppServices _services;

        public OrderItemController(IOrderItemAppServices services)
        {
            _services = services;
        }

        // GET: api/<OrderItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderItemRequest request)
        {

            var data = await _services.Add(new OrderItem()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                UnitPrice = request.UnitPrice,
                Amount = request.Amount,
    });

            return Ok(data);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditOrderItemRequest request)
        {
            await _services.Update(new()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                UnitPrice = request.UnitPrice,
                Amount = request.Amount,

            });

            return Accepted();
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}
