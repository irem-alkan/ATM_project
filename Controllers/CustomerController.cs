using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMWithdrawalApi.Models;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers
                //.Include(c => c.Accounts)
               // .Include(c => c.CustomerRelations)
                //.Include(c => c.CustomerJobs)
               // .Include(c => c.DebtPayments)
                .ToListAsync();

            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer(int customerId)
        {
            var customer = await _context.Customers
               // .Include(c => c.Accounts)
                //.Include(c => c.CustomerRelations)
               // .Include(c => c.CustomerJobs)
               // .Include(c => c.DebtPayments)
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { customerId = customer.Id }, customer);
        }
/*
        // PUT: api/Customer/5
        [HttpPut("{ID_Customer}")]
        public async Task<IActionResult> UpdateCustomer(long ID_Customer, Customer customer)
        {
            if (ID_Customer != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(ID_Customer))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{ID_Customer}")]
        public async Task<IActionResult> DeleteCustomer(long ID_Customer)
        {
            var customer = await _context.Customers.FindAsync(ID_Customer);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(long ID_Customer)
        {
            return _context.Customers.Any(e => e.ID_Customer == ID_Customer);
        }*/
    }
}

      