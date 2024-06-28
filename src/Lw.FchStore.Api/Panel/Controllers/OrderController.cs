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
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderRequest request)
        {

            var data = await _services.Add(new Order()
            {
                Status = request.Status,
                ClientId = request.ClientId,
                TotalValue = 0,
                ClientAddressId = request.ClientAddressId,
                PaymentId = request.PaymentId,
                IsActive = true,
                CreatedAt = DateTime.Now

    });

            return Ok(data);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditOrderRequest request)
        {
            await _services.Update(new()
            {
                Status = request.Status,
                ClientId = request.ClientId,
                TotalValue = request.TotalValue,
                ClientAddressId = request.ClientAddressId,
                PaymentId = request.PaymentId,
                IsActive = request.IsActive,

            });

            return Accepted();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}
