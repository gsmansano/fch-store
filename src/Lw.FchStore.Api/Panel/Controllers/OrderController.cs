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
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var data = await _services.GetAll();

            var totalItems = data.Count();

            var paginatedData = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var paginationMetadata = new
            {
                totalCount = totalItems,
                pageSize,
                currentPage = pageNumber,
                totalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return Ok(new { data = paginatedData, pagination = paginationMetadata });

        }


        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var order = await _services.PanelGetOrderById(id);

            return Ok(order);

        }

        // GET api/<OrderController>/5
        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetByClientId(int clientId)
        {

            var orders = await _services.GetByClientId(clientId);

            return Ok(orders);

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReadyToShip(int id)
        {

            var order = await _services.GetById(id);

            order.Status = (OrderStatus)4; // ready do ship

            await _services.Update(order);

            return Accepted();

        }
        
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipped(int id)
        {

            var order = await _services.GetById(id);

            order.Status = (OrderStatus)5; // Shipped

            await _services.Update(order);

            return Accepted();

        } 
        
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompleted(int id)
        {

            var order = await _services.GetById(id);

            order.Status = (OrderStatus)7; // Completed

            await _services.Update(order);

            return Accepted();

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanceled(int id)
        {

            var order = await _services.GetById(id);

            order.Status = (OrderStatus)90; // Canceled

            await _services.Update(order);

            return Accepted();

        }

    }
}
