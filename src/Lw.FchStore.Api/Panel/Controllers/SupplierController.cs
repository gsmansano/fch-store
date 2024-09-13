using Azure.Core;
using Lw.FchStore.Api.Panel.Request.Manufacturer;
using Lw.FchStore.Api.Panel.Request.Supplier;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Lw.FchStore.Api.Panel.Controllers
{
    [Route("panel/api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManage")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppServices _services;

        public SupplierController(ISupplierAppServices services)
        {
            _services = services;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSupplierRequest request)
        {
            var data = await _services.Add(new Supplier() { 
                Name = request.Name,
                FullAddress = request.FullAddress,
                ZipCode = request.ZipCode,
                ContactName = request.ContactName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                VatNumber = request.VatNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,              
            
            });

            return Ok(data);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditSupplierRequest value)
        {
            var existing = await _services.GetById(id);

            if (existing == null)
            {
                return NotFound("Supplier not found.");
            }

            existing.Name = value.Name;
            existing.FullAddress = value.FullAddress;
            existing.ZipCode = value.ZipCode;
            existing.ContactName = value.ContactName;
            existing.PhoneNumber = value.PhoneNumber;
            existing.EmailAddress = value.EmailAddress;
            existing.VatNumber = value.VatNumber;
            existing.IsActive = value.IsActive;

            await _services.Update(existing);

            return Accepted();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}