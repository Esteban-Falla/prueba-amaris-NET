using EmployeesSite.Models;

namespace EmployeesSite.Interfaces;

public interface IRepository<Entity>
where Entity : IEntity
{
    public Task<RequestMessage<Entity>> GetAllAsync();
    public Task<RequestMessage<Entity>> GetByIdAsync(int id);
}