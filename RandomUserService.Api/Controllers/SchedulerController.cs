using Microsoft.AspNetCore.Mvc;
using RandomUserService.Api.Background;

namespace RandomUserService.Api.Controllers;

[ApiController]
[Route("api/scheduler")]
public class SchedulerController : ControllerBase
{
    private readonly UserFetchScheduler _scheduler;

    public SchedulerController(UserFetchScheduler scheduler)
    {
        _scheduler = scheduler;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new { status = _scheduler.Status });
    }

    [HttpGet("start")]
    public IActionResult Start()
    {
        _scheduler.Start();
        return Ok(new { status = _scheduler.Status });
    }

    [HttpPost("pause")]
    public IActionResult Pause()
    {
        _scheduler.Pause();
        return Ok(new { status = _scheduler.Status });
    }

    [HttpPost("resume")]
    public IActionResult Resume()
    {
        _scheduler.Resume();
        return Ok(new { status = _scheduler.Status });
    }
}