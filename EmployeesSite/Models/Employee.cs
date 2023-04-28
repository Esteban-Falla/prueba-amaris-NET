using EmployeesSite.Interfaces;

namespace EmployeesSite.Models
{
    public class Employee:IEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; private set; }
        [JsonPropertyName("employee_name")]
        public string Name { get; private set; }
        [JsonPropertyName("employee_salary")]
        public long Salary { get; private set; }
        [JsonPropertyName("employee_age")]
        public short Age { get; private set; }
        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; private set; }
    }
}