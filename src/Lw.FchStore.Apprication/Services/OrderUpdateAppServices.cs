using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.FchStore.Application.Services
{
    public class OrderUpdateAppServices : AppServices<OrderUpdate>, IOrderUpdateAppServices
    {
        private readonly IOrderUpdateRepository _repository;

        public OrderUpdateAppServices(IOrderUpdateRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
