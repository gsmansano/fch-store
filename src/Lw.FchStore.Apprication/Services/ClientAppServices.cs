using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;

namespace Lw.FchStore.Application.Services;

public class ClientAppServices : AppServices<Client>, IClientAppServices
{
    private readonly IClientRepository _repository;

    public ClientAppServices(IClientRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Client> Add(string name)
    {
        var client = new Client()
        {
            Name = name,
            IsActive = true
        };

        return await _repository.Add(client);
    }
}

