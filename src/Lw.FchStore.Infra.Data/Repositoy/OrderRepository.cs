using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Lw.FchStore.Domain.Responses;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private LwContext _context;

        public OrderRepository(LwContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OrderDetailsResponse>> GetByClientId(int clientId)
        {
            var orders = await DbSet.Where(o => o.ClientId == clientId)
                            .Include(o => o.Client)
                            .Include(o => o.Address)
                            .Select(o => new OrderDetailsResponse()
                            {
                                OrderId = o.OrderId,
                                Status = o.Status,
                                ClientId = o.ClientId,
                                TotalValue = o.TotalValue,
                                ClientAddressId = o.ClientAddressId,
                                PaymentId = o.PaymentId,
                                CreatedAt = o.CreatedAt,

                                Client = new ClientDetailsResponse()
                                {
                                    ClientId = o.Client.ClientId,
                                    Fullname = o.Client.Fullname,
                                    Email = o.Client.Email,
                                    PhoneNumber = o.Client.PhoneNumber
                                },

                                Address = new ClientAddressResponse()
                                {
                                    ClientAddressId = o.Address.ClientAddressId,
                                    AddressLine1 = o.Address.AddressLine1,
                                    AddressLine2 = o.Address.AddressLine2,
                                    AddressLine3 = o.Address.AddressLine3,
                                    City = o.Address.City,
                                    Country = o.Address.Country,
                                    ZipCode = o.Address.ZipCode
                                }
                            })
                            .ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Order
           .Include(o => o.Client)
           .Include(o => o.Address)
           .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
           .FirstOrDefaultAsync(o => o.OrderId == id);

        }

        public async Task<OrderDetailsResponse> PanelGetOrderById(int orderId)
        {
            var data = await DbSet.Include(o => o.Client)
                                  .ThenInclude(c => c.Addresses)
                                  .Include(o => o.Address)
                                  .Select(o => new OrderDetailsResponse()
                                  {
                                      OrderId = o.OrderId,
                                      Status = o.Status,
                                      ClientId = o.ClientId,
                                      TotalValue = o.TotalValue,
                                      ClientAddressId = o.ClientAddressId,
                                      PaymentId = o.PaymentId,
                                      CreatedAt = o.CreatedAt,

                                      Client = new ClientDetailsResponse()
                                      {
                                          ClientId = o.Client.ClientId,
                                          Fullname = o.Client.Fullname,
                                          Email = o.Client.Email,
                                          PhoneNumber = o.Client.PhoneNumber
                                      },

                                      Address = new ClientAddressResponse()
                                      {
                                          ClientAddressId = o.Address.ClientAddressId,
                                          AddressLine1 = o.Address.AddressLine1,
                                          AddressLine2 = o.Address.AddressLine2,
                                          AddressLine3 = o.Address.AddressLine3,
                                          City = o.Address.City,
                                          Country = o.Address.Country,
                                          ZipCode = o.Address.ZipCode
                                      }
                                  }).FirstOrDefaultAsync(o => o.OrderId == orderId);

            return data;
        }


    }


}
