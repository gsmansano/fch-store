using Azure.Core;
using Lw.FchStore.Api.Panel.Request.Manufacturer;
using Lw.FchStore.Api.Panel.Request.Unit;
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
    public class UnitController : ControllerBase
    {
        private readonly IUnitAppServices _services;

        public UnitController(IUnitAppServices services)
        {
            _services = services;
        }

        // GET: api/<UnitController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<UnitController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUnitRequest request)
        {

            var data = await _services.Add(new Unit() { Name = request.Name, IsActive = true });

            return Ok(data);
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditUnitRequest request)
        {
            await _services.Update(new() { UnitId = id, Name = request.Name, IsActive = request.IsActive });

            return Accepted();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}