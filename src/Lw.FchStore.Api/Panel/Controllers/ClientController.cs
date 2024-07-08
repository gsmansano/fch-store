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
    public class ClientController : ControllerBase
    {

        private readonly IClientAppServices _services;

        public ClientController(IClientAppServices services)
        {
            _services = services;
        }

        // GET: api/<ClientController>
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

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.PanelGetById(id);

            return Ok(data);
        }

        // PUT api/<ClientController>/5
        [HttpPut("Enable/{id}")]
        public async Task<IActionResult> Enable(int id)
        {

            var client = await _services.GetById(id);

            client.IsActive = true;

            await _services.Update(client);

            return Accepted();
        }
        
        // PUT api/<ClientController>/5
        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            var client = await _services.GetById(id);

            client.IsActive = false;

            await _services.Update(client);

            return Accepted();
        }

    }
}
