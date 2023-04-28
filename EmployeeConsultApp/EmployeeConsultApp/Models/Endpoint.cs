using EmployeeConsultApp.Interfaces;

namespace EmployeeConsultApp.Models;

public class Endpoint<T>
    where T : IEntity
{
    public string Value { get; set; }
}