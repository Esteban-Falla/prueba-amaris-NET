using EmployeesSite.Interfaces;

namespace EmployeesSite.Models;

public class Endpoint<T>
where T : IEntity
{
    public string Value { get; set; }
}