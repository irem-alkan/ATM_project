using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATM_project.Models;
using System.Threading.Tasks;
using ATMWithdrawalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext, ApplicationDbContext context, ILogger<CustomerController> logger)
        {
            _dbContext = dbContext;
            _context = context;
            _logger = logger;
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }
    }
}
