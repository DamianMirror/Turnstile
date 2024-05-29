using Microsoft.AspNetCore.Mvc;

namespace lab32
{
    [ApiController]
    [Route("[controller]")]
    public class PassInfoController : ControllerBase
    {
        [HttpPost("create-pass")]
        public IActionResult CreatePass(string name, Status status, PassTypes passType, int securityLevel = 1, int passesAmountLeft = 0)
        {
            // Використовуємо будівельника для створення PassInfo
            var passBuilder = new PassInfoBuilder();
            PassInfo pass = passBuilder
                .SetName(name)
                .SetStatus(status)
                .SetPassType(passType)
                .SetSecurityLevel(securityLevel)
                .SetPassesAmountLeft(passesAmountLeft)
                .Build();

            UsersBase.Users.Add(pass);
            return Ok();
        }
    }
}