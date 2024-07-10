/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ATM_project.Data;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       /* private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
            => (_configuration, _logger) = (configuration, logger);

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [SwaggerOperation(Summary = "Authenticate user and return JWT token")]
        [SwaggerResponse(200, "JWT token", typeof(string))]
        [SwaggerResponse(401, "Unauthorized")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Login endpoint hit");

            if (request.Username != "SIremAlkan\\alkan" || request.Password != "kullaniciSifresi")
            {
                _logger.LogWarning("Invalid username or password");
                return Unauthorized();
            }

            var roles = new[] { "User", "Admin" };

            var token = GenerateJwtToken(request.Username, roles);

            return Ok(new { token });
        }

        private string GenerateJwtToken(string username, string[] roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey) || Encoding.UTF8.GetBytes(jwtKey).Length < 16)
            {
                throw new InvalidOperationException("Invalid JWT key configuration.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            _logger.LogInformation("JWT token generated for user {username}", username);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
/* }
/*
 public class LoginRequest
 {
     public string? Username { get; set; }
     public string? Password { get; set; }
 }}*/





using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ATM_project.Models; // LoginRequest için gerekli
using Swashbuckle.AspNetCore.Annotations;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [SwaggerOperation(Summary = "Authenticate user and return JWT token")]
        [SwaggerResponse(200, "JWT token", typeof(string))]
        [SwaggerResponse(401, "Unauthorized")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Login endpoint hit");

            if (request.Username != "SIremAlkan\\alkan" || request.Password != "kullaniciSifresi")
            {
                _logger.LogWarning("Invalid username or password");
                return Unauthorized();
            }

            var roles = new[] { "User", "Admin" };

            var token = GenerateJwtToken(request.Username, roles);

            return Ok(new { token });
        }

        private string GenerateJwtToken(string username, string[] roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtKey = "your_jwt_secret_key"; // JWT secret key burada belirtildi
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your_issuer",
                audience: "your_audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            _logger.LogInformation("JWT token generated for user {username}", username);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
