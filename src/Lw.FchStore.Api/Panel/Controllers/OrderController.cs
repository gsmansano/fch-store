using Lw.FchStore.Api.Panel.Request.Order;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lw.FchStore.Api.Panel.Controllers
{
    [Route("panel/api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManage")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderAppServices _services;

        public OrderController(IOrderAppServices services)
        {
            _services = services;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var order = await _services.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var result = new
            {
                order.OrderId,
                order.Status,
                order.ClientId,
                order.TotalValue,
                order.ClientAddressId,
                order.PaymentId,
                order.IsActive,
                order.CreatedAt,
                Client = new
                {
                    order.Client.ClientId,
                    order.Client.Fullname
                },
                ClientAddress = new
                {
                    order.Address.ClientAddressId,
                    order.Address.AddressLine1
                },
                OrderItems = order.Items.Select(oi => new
                {
                    oi.OrderItemId,
                    Product = new
                    {
                        oi.Product.ProductId,
                        oi.Product.Name
                    },
                    oi.Amount
                })
            };

            return Ok(result);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditOrderRequest request)
        {
            await _services.Update(new()
            {
                Status = request.Status,
            });

            return Accepted();
        }

    }
}
