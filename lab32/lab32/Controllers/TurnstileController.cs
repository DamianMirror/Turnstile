// TurnstileController.cs

using System.ComponentModel.DataAnnotations;
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
    
    [HttpPut("pass-through")]
    public IActionResult PassThrough(int IdNums, GateAction action)
    {
        _turnstile.PassThrough(UsersBase.Users[IdNums], action);
        return Ok();
    }

    [HttpGet("display-passes")]
    public IActionResult DisplayPasses()
    {
        _turnstile.PrintPasses();
        return Ok();
    }
}