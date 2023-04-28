using System.Text.Json.Serialization;
using EmployeeConsultApp.Core.Interfaces;

namespace EmployeeConsultApp.Core.Models;

public sealed class RequestMessage<Entity>
    where Entity : IEntity
{
    [JsonPropertyName("status")] public string Status { get; init; }

    [JsonPropertyName("data")] public IEnumerable<Entity> Data { get; init; }

    [JsonPropertyName("message")] public string Message { get; init; }
}