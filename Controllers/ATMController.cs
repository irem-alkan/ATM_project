/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ATM_project.Data;
using System;
//using ATM_project.Models;

namespace ATM_project.Controllers.ATM
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        private readonly ILogger<ATMController> _logger;
        private readonly AppDbContext _context;

        public ATMController(ILogger<ATMController> logger, AppDbContext context)
       => (_logger, _context) = (logger, context);


      /*  [HttpPost("login")]
        public IActionResult Login([FromBody] ATM_project.Controllers.ATM.LoginRequest request)
        {
            _logger.LogInformation("Login request received.");

            if (request.Username != "SIremAlkan\\alkan" || request.Password != "kullaniciSifresi")
            {
                _logger.LogWarning("Invalid username or password");
                return Unauthorized();
            }

            return Ok(new { message = "Login successful" });
        }*/
/*  }
  public class LoginRequest
  {
      public string? Username { get; set; }
      public string? Password { get; set; }
  }
}
*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATM_project.Models; // LoginRequest için gerekli

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly ILogger<ATMController> _logger;

        public ATMController(ILogger<ATMController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Login request received.");

            if (request.Username != "SIremAlkan\\alkan" || request.Password != "kullaniciSifresi")
            {
                _logger.LogWarning("Invalid username or password");
                return Unauthorized();
            }

            return Ok(new { message = "Login successful" });
        }
    }
}
