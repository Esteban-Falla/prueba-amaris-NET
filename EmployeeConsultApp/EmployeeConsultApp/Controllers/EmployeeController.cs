using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeConsultApp.Converter;
using EmployeeConsultApp.Core.Interfaces;
using EmployeeConsultApp.Core.Models;
using EmployeeConsultApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeConsultApp.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<IRepository<Employee>> _logger;
    private readonly IRepository<Employee> _repository;

    public EmployeeController(IRepository<Employee> repository, ILogger<IRepository<Employee>> logger)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet("/")]
    [Produces("application/json", Type = typeof(IEnumerable<EmployeeViewModel>))]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation($"{nameof(EmployeeController)}:{nameof(GetAll)}");

        try
        {
            var result = await _repository.GetAllAsync();

            if (!(result != null) || result.Status != "success")
            {
                _logger.LogWarning($"Problem finding employees, request responded with: {result?.Message}");
                return View(Array.Empty<EmployeeViewModel>());
            }

            return View(result.Data
                .Select(EmployeeViewModelConverter.FromCoreEmployee));
        }
        catch (Exception e)
        {
            _logger.LogError(null, string.Empty, e);
            return Error();
        }
    }

    [HttpPost("search")]
    [HttpGet("search/{Id:int}")]
    [Produces("application/json", Type = typeof(EmployeeViewModel))]
    public async Task<IActionResult> GetById(int Id)
    {
        _logger.LogInformation($"{nameof(EmployeeController)}:{nameof(GetById)} with Id: {Id}");
        ViewBag.Failed = false;
        try
        {
            var result = await _repository.GetByIdAsync(Id);

            if (!(result != null) || result.Status != "success")
            {
                _logger.LogWarning(
                    $"Problem finding employee with id: {Id}, request responded with: {result?.Message}");
                ViewBag.Failed = true;
                return View();
            }

            return View(
                EmployeeViewModelConverter.FromCoreEmployee(
                    result.Data.FirstOrDefault()));
        }
        catch (Exception e)
        {
            _logger.LogError(null, string.Empty, e);
            return Error();
        }
    }

    [HttpGet("search")]
    [Produces("application/json", Type = typeof(EmployeeViewModel))]
    public async Task<IActionResult> GetById()
    {
        _logger.LogInformation($"{nameof(EmployeeController)}:{nameof(GetById)} no Id");
        ViewBag.Failed = false;
        return View("GetById", null);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogWarning($"{nameof(EmployeeController)}:{nameof(Error)}");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}