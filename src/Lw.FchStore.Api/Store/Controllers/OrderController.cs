using Lw.FchStore.Api.Store.Request.Order;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lw.FchStore.Api.Store.Controllers
{
    [Route("store/api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppServices _services;

        public OrderController(IOrderAppServices services)
        {
            _services = services;
        }


        // GET: api/<OrderController>

        // pegar todos so do client

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

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderRequest request)
        {

            var data = await _services.Add(new Order()
            {
                Status = OrderStatus.Open,
                TotalValue = 0,

            });

            return Ok(data);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditOrderRequest request)
        {
            await _services.Update(new()
            {
                // update de pedido pode ser:
                // add order item
                // update order item   --> todos atualiza o total value
                // delete order item
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
