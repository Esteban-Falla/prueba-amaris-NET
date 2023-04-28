using System.Text.Json.Serialization;
using EmployeeConsultApp.Core.Interfaces;

namespace EmployeeConsultApp.Core.Models;

public class Employee : IEntity
{
    [JsonPropertyName("id")] public int Id { get; init; }

    [JsonPropertyName("employee_name")] public string Name { get; init; }

    [JsonPropertyName("employee_salary")] public long Salary { get; init; }

    [JsonPropertyName("employee_age")] public short Age { get; init; }

    [JsonPropertyName("profile_image")] public string ProfileImage { get; init; }
}