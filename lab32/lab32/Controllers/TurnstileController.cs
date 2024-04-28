// TurnstileController.cs
using Microsoft.AspNetCore.Mvc;
using lab32;

[ApiController]
[Route("[controller]")]
public class TurnstileController : ControllerBase
{
    private ITurnstile _turnstile;

    public TurnstileController(ITurnstile turnstile)
    {
        _turnstile = turnstile;
    }

    [HttpPost("create")]
    public IActionResult CreateTurnstile(Status type, PassTypes passTypeNeeded, int securityLevel = 1)
    {
        _turnstile = new Turnstile(type, passTypeNeeded, securityLevel);
        return Ok();
    }

    [HttpPut("pass-through")]
    public IActionResult PassThrough(PassInfo pass, GateAction action)
    {
        _turnstile.PassThrough(pass, action);
        return Ok();
    }

    [HttpGet("display-passes")]
    public DoublyLinkedList DisplayPasses()
    {
        return _turnstile.GetLogs();
    }
}