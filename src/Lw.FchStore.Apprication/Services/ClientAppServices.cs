using Lw.FchStore.Application.Builder;
using Lw.FchStore.Domain.Entities;
using Lw.FchStore.Domain.Interfaces.Repositories;
using Lw.FchStore.Domain.Interfaces.Services;
using Lw.FchStore.Domain.Responses;

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
            Fullname = name,
            IsActive = true
        };

        return await _repository.Add(client);
    }

    public async Task<ClientDataResponse> PanelGetById(int id)
    {
        var data = await _repository.PanelGetById(id);

        return data;

    }
}

