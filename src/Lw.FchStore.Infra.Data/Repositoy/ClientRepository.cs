using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(LwContext context) : base(context)
        {
        }

        public async Task<ClientDataResponse> PanelGetById(int id)
        {
            var data = await DbSet.Include(p => p.Addresses).Include(p => p.Orders).Select(p => new ClientDataResponse()
            {
                ClientId = p.ClientId,
                Fullname = p.Fullname,
                DateOfBirth = p.DateOfBirth,
                DocumentNumber = p.DocumentNumber,
                Email = p.Email,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,

                Addresses = p.Addresses.ToList(),
                Orders = p.Orders.Select(a => a.OrderId).ToList()

            }).FirstOrDefaultAsync(p => p.ClientId == id);

            return data;
        }
    }


}
