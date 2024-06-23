using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Infra.Data.Base;
using Lw.FchStore.Infra.Data.Context;
using Lw.FchStore.Domain.Interfaces.Repositories;

namespace Lw.FchStore.Infra.Data.Repositoy
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(LwContext context) : base(context)
        {
        }
    }


}
