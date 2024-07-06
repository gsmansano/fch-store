using Lw.FchStore.Api.Store.Request.ClientAddress;
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
    public class ClientAddressController : ControllerBase
    {
        private readonly IClientAddressAppServices _services;

        public ClientAddressController(IClientAddressAppServices services)
        {
            _services = services;
        }

        //// GET: api/<ClientAddressController>
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var data = await _services.GetAll();

        //    return Ok(data.ToList());
        //}

        // GET api/<ClientAddressController>/5
        [HttpGet("{clientId}/{clientAddressId}")]
        public async Task<IActionResult> Get(int clientId, int clientAddressId)
        {
            ClientAddress data = await _services.GetById(clientId, clientAddressId);

            return Ok(data);
        }

        // POST api/<ClientAddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddClientAddressRequest request)
        {

            var data = await _services.Add(new ClientAddress()
            {
                AddressLine1 = request.FullAddress,
                City = request.City,
                Country = request.Country,
                ZipCode = request.ZipCode,
                IsActive = true
            });

            return Ok(data);
        }

        // PUT api/<ClientAddressController>/5
        [HttpPut("{clientId}/{clientAddressId}")]
        public async Task<IActionResult> Put(int clientId, int clientAddressId, [FromBody] EditClientAddressRequest request)
        {
            await _services.Update(new()
            {

                ClientId = request.ClientId,
                AddressLine1 = request.FullAddress,
                City = request.City,
                Country = request.Country,
                ZipCode = request.ZipCode,
                IsActive = request.IsActive

            });

            return Accepted();
        }

        // DELETE api/<ClientAddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Remove(id);

            return Accepted();
        }

    }
}
