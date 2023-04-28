using EmployeeConsultApp.Core.Models;

namespace EmployeeConsultApp.Core.Interfaces;

public interface IRepository<Entity>
    where Entity : IEntity
{
    public Task<RequestMessage<Entity>> GetAllAsync();
    public Task<RequestMessage<Entity>> GetByIdAsync(int id);
}