using System;
using System.Net.Http;
using System.Net.Http.Headers;
using EmployeeConsultApp.Interfaces;
using EmployeeConsultApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeConsultApp.Repositories;

public abstract class BaseRepository<Entity> : IRepository<Entity>
    where Entity : IEntity
{
    private protected readonly Endpoint<Entity> _endpoint;
    private protected readonly ILogger<IRepository<Entity>> _logger;

    protected BaseRepository(IOptions<Endpoint<Entity>> endpoint, ILogger<IRepository<Entity>> logger)
    {
        _endpoint = endpoint?.Value ?? throw new ArgumentNullException(nameof(endpoint));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public virtual async Task<RequestMessage<Entity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<RequestMessage<Entity>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    protected HttpClient GetClient(string uri)
    {
        if (string.IsNullOrEmpty(uri))
            throw new ArgumentNullException(nameof(uri));

        var client = new HttpClient();
        client.BaseAddress = new Uri(uri);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}