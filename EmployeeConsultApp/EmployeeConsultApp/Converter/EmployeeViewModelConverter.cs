using EmployeeConsultApp.Core.Models;
using EmployeeConsultApp.Models;

namespace EmployeeConsultApp.Converter;

public class EmployeeViewModelConverter
{
    public static EmployeeViewModel FromCoreEmployee(Employee source)
    {
        return new EmployeeViewModel
        {
            Id = source.Id,
            Name = source.Name,
            Age = ushort.Parse(source.Age.ToString()),
            Salary = ulong.Parse(source.Salary.ToString()),
            ProfileImage = source.ProfileImage
        };
    }
}