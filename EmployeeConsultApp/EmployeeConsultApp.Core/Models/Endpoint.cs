using EmployeeConsultApp.Core.Interfaces;

namespace EmployeeConsultApp.Core.Models;

public class Endpoint<T>
    where T : IEntity
{
    public string Value { get; set; }
}