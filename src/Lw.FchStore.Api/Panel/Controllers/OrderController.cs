using Lw.FchStore.Api.Panel.Request.Order;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lw.FchStore.Api.Panel.Controllers
{
    [Route("panel/api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManage")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderAppServices _services;
        private readonly IOrderUpdateAppServices _updateServices;

        public OrderController(IOrderAppServices services, IOrderUpdateAppServices updateServices)
        {
            _services = services;
            _updateServices = updateServices;
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
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetByClientId(int clientId)
        {

            var orders = await _services.GetByClientId(clientId);

            return Ok(orders);

        }

        // PUT api/<OrderController>/5
        [HttpPut("ready-to-ship/{id}")]
        public async Task<IActionResult> PutReadyToShip(int orderId)
        {

            var order = await _services.GetById(orderId);

            order.Status = (OrderStatus)4; // ready to ship

            await _services.Update(order);

            var orderUpdate = new OrderUpdate
            {
                OrderId = orderId,
                UpdateTime = DateTime.UtcNow,
                Description = $"Order updated to ready to ship at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
                Status = (OrderStatus)4,
            };

            await _updateServices.Add(orderUpdate);

            return Accepted();

        }

        // PUT api/<OrderController>/5
        [HttpPut("shipped/{id}")]
        public async Task<IActionResult> PutShipped(int orderId)
        {

            var order = await _services.GetById(orderId);

            order.Status = (OrderStatus)5; // Shipped

            await _services.Update(order);

            var orderUpdate = new OrderUpdate
            {
                OrderId = orderId,
                UpdateTime = DateTime.UtcNow,
                Description = $"Order updated to shipped at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
                Status = (OrderStatus)5,
            };

            await _updateServices.Add(orderUpdate);

            return Accepted();

        }

        // PUT api/<OrderController>/5
        [HttpPut("completed/{id}")]
        public async Task<IActionResult> PutCompleted(int orderId)
        {

            var order = await _services.GetById(orderId);

            order.Status = (OrderStatus)7; // Completed

            await _services.Update(order);

            var orderUpdate = new OrderUpdate
            {
                OrderId = orderId,
                UpdateTime = DateTime.UtcNow,
                Description = $"Order updated to completed at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
                Status = (OrderStatus)7,
            };

            await _updateServices.Add(orderUpdate);

            return Accepted();

        }

        // PUT api/<OrderController>/5
        [HttpPut("canceled/{id}")]
        public async Task<IActionResult> PutCanceled(int orderId)
        {

            var order = await _services.GetById(orderId);

            order.Status = (OrderStatus)90; // Canceled

            await _services.Update(order);

            var orderUpdate = new OrderUpdate
            {
                OrderId = orderId,
                UpdateTime = DateTime.UtcNow,
                Description = $"Order updated to canceled at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
                Status = (OrderStatus)90,
            };

            await _updateServices.Add(orderUpdate);

            return Accepted();

        }

    }
}
