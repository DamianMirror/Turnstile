using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace lab32;

[ApiController]
[Route("[controller]")]
public class PassInfoController : ControllerBase
{
    [HttpPost("create-pass")]
    public IActionResult CreatePass(string name, Status status, PassTypes passType, int securityLevel = 1, int passesAmountLeft = 0)
    {
        PassInfo pass = new PassInfo(name, status, passType, securityLevel, passesAmountLeft);
        UsersBase.Users.Add(pass);
        return Ok();
    }
}