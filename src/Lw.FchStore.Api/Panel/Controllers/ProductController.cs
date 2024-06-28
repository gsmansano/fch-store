using Lw.FchStore.Api.Panel.Request.Product;
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
    public class ProductController : ControllerBase
    {

        private readonly IProductAppServices _services;

        public ProductController(IProductAppServices services)
        {
            _services = services;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest request)
        {

            var data = await _services.Add(new Product()
            {
                SupplierId = request.SupplierId,
                ManufacturerId = request.ManufacturerId,
                UnitId = request.UnitId,
                Name = request.Name,
                Description = request.Description,
                CostPrice = request.CostPrice,
                SalePrice = request.SalePrice,
                IsActive = true,
                CreatedAt = DateTime.Now

    });

            return Ok(data);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditProductRequest request)
        {
            await _services.Update(new()
            {

                SupplierId = request.SupplierId,
                ManufacturerId = request.ManufacturerId,
                UnitId = request.UnitId,
                Name = request.Name,
                Description = request.Description,
                CostPrice = request.CostPrice,
                SalePrice = request.SalePrice,
                IsActive = request.IsActive,

            });

            return Accepted();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}
