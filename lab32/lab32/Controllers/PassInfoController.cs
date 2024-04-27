using Microsoft.AspNetCore.Mvc;

namespace lab32.Controllers;

[ApiController]
[Route("[controller]")]
public class PassInfoController : ControllerBase
{

    private readonly ILogger<PassInfoController> _logger;

    public PassInfoController(ILogger<PassInfoController> logger)
    {
        _logger = logger;
    }

    [HttpPost("create-pass")]
    public IActionResult CreatePass(string name, Status status, PassTypes passType, int securityLevel = 1, int passesAmountLeft = 0)
    {
        PassInfo pass = new PassInfo(name, status, passType, securityLevel, passesAmountLeft);
        return Ok();
    }
}