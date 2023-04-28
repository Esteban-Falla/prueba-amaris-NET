using EmployeeConsultApp.Interfaces;

namespace EmployeeConsultApp.Models;

public sealed class RequestMessage<Entity>
    where Entity : IEntity
{
    [JsonPropertyName("status")] public string Status { get; private set; }

    [JsonPropertyName("data")] public IEnumerable<Entity> Data { get; private set; }

    [JsonPropertyName("message")] public string Message { get; private set; }
}