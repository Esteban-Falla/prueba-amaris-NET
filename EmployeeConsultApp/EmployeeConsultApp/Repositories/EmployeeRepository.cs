using System;
using System.Text.Json;
using EmployeeConsultApp.Interfaces;
using EmployeeConsultApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeConsultApp.Repositories;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(IOptions<Endpoint<Employee>> endpoint, ILogger<IRepository<Employee>> logger)
        : base(endpoint, logger)
    {
    }

    public override async Task<RequestMessage<Employee>> GetAllAsync()
    {
        _logger.LogInformation($"Method called: {nameof(GetAllAsync)}");
        using var client = GetClient($"{_endpoint.Value}s");
        try
        {
            var response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"{nameof(GetAllAsync)} call success with status: {response.StatusCode}");
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RequestMessage<Employee>>(result);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return null;
    }

    public override async Task<RequestMessage<Employee>> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Method called: {nameof(GetByIdAsync)}");
        using var client = GetClient($"{_endpoint.Value}");
        try
        {
            var response = await client.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"{nameof(GetByIdAsync)} call success with status: {response.StatusCode}");
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RequestMessage<Employee>>(result);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return null;
    }
}