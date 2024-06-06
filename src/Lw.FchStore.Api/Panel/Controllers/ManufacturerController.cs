using Lw.FchStore.Api.Panel.Request.Manufacturer;
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
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerAppServices _services;

        public ManufacturerController(IManufacturerAppServices services)
        {
            _services = services;
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<ManufacturerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<ManufacturerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddManufacturerRequest value)
        {
            var data = await _services.Add(value.Name);

            return Ok(data);
        }

        // PUT api/<ManufacturerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditManufacturerRequest value)
        {
            await _services.Update(new() { ManufacturerId = id, Name = value.Name, IsActive = value.IsActive });

            return Accepted();
        }

        // DELETE api/<ManufacturerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}