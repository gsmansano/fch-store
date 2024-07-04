using Lw.FchStore.Api.Store.Request.OrderItem;
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
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemAppServices _services;

        public OrderItemController(IOrderItemAppServices services)
        {
            _services = services;
        }


    }
}
