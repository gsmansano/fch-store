using Lw.FchStore.Api.Panel.Request.Category;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppServices _services;

        public CategoryController(ICategoryAppServices services)
        {
            _services = services;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();

            return Ok(data.ToList());
        } 
        
        // GET: api/<CategoryController>
        [HttpGet("Tree")]
        public async Task<IActionResult> GetTree()
        {
            var data = await _services.GetTree();

            return Ok(data.ToList());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);

            return Ok(data);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryRequest request)
        {
          
            var data = await _services.Add( new Category() { Name = request.Name, IsActive = true });

            return Ok(data);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditCategoryRequest request)
        {
            await _services.Update(new() { CategoryId = id, Name = request.Name, IsActive = request.IsActive });

            return Accepted();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }
    }
}