using System.ComponentModel.DataAnnotations;

namespace EmployeeConsultApp.Models;

public class EmployeeViewModel
{
    [Display(Name = "Employee Id", ShortName = "EmpId")]
    [Range(0, int.MaxValue)]
    [Required]
    public int Id { get; init; }

    [Display(Name = "Full Name", ShortName = "AmpName")]
    [Required]
    public string Name { get; init; }

    [Display(Name = "Salary", ShortName = "Salary")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Range(0, ulong.MaxValue)]
    [Required]
    public ulong Salary { get; init; }

    [Display(Name = "Annual Employee Salary", ShortName = "AnnualSalary")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public ulong AnnualSalary => Salary * 12;

    [Display(Name = "Age", ShortName = "Age")]
    [Range(0, ushort.MaxValue)]
    public ushort Age { get; init; }

    [Display(Name = "Picture", ShortName = "ProfImage")]
    [Url]
    public string ProfileImage { get; init; }
}