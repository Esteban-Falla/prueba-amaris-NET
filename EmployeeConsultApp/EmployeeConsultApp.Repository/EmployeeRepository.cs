using System.Text.Json;
using EmployeeConsultApp.Core.Interfaces;
using EmployeeConsultApp.Core.Models;
using EmployeeConsultApp.Core.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeConsultApp.Repository;

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
            
            _logger.LogWarning(
                $"{nameof(GetAllAsync)}: Could not find user info. Request status: {response?.StatusCode}");
        }
        catch (Exception e)
        {
            _logger.LogError(null, string.Empty, e);
            throw;
        }

        return null;
    }

    public override async Task<RequestMessage<Employee>> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Method called: {nameof(GetByIdAsync)}");
        using var client = GetClient($"{_endpoint.Value}/{id}");
        try
        {
            var response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"{nameof(GetByIdAsync)} call success with status: {response.StatusCode}");
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RequestMessage<Employee>>(result);
            }

            _logger.LogWarning(
                $"{nameof(GetByIdAsync)}: Could not find user with id: {id}. Request status: {response?.StatusCode}");
        }
        catch (Exception e)
        {
            _logger.LogError(null, string.Empty, e);
            throw;
        }

        return null;
    }
}