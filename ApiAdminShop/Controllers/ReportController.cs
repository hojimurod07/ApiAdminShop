using Application.Common.ReportModels;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAdminShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("annual")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetAnnualReportAsync([FromQuery] int year)
    {
        var report = new AnnualReport { Year = new DateOnly(year, 1, 1) };
        var result = await _reportService.GetAnnualReportAsync(report);
        return Ok(result);
    }

    [HttpGet("daily")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetDailyReportAsync([FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
    {
        var report = new DailyReport { Day = new DateOnly(year, month, day) };
        var result = await _reportService.GetDailyReportAsync(report);
        return Ok(result);
    }

    [HttpGet("monthly")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetMonthlyReportAsync([FromQuery] int year, [FromQuery] int month)
    {
        var report = new MonthlyReport { Monthly = new DateOnly(year, month, 1) };
        var result = await _reportService.GetMonthlyReportAsync(report);
        return Ok(result);
    }
}