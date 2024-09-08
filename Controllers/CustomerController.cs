using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ATM_project.Services;
using ATMWithdrawalApi.Models;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public CustomerController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(
            [FromQuery] string name = null,
            [FromQuery] string surname = null,
            [FromQuery] string tc = null)
        {
            var query = _context.Customers
                .Include(c => c.CustomerJobs)
                .Include(c => c.CustomerRelations)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(surname))
            {
                query = query.Where(c => c.Surname.Contains(surname));
            }

            if (!string.IsNullOrEmpty(tc))
            {
                query = query.Where(c => c.TC == tc);
            }

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(tc))
            {
                return Ok(new List<Customer>());
            }


            var customers = await query.ToListAsync();
            return Ok(customers);
        }



        // GET: api/Customer/5
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer(int customerId)
        {
            var customer = await _context.Customers
                .Include(c => c.CustomerJobs)
                .Include(c => c.CustomerRelations)
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
                return BadRequest(new
                {
                    message = "Model validation failed.",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

            if (string.IsNullOrEmpty(customer.Email))
            {
                return BadRequest("Customer email cannot be null or empty.");
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();

                    var emailRequest = new
                    {
                        ToEmail = customer.Email,
                        Subject = "Welcome",
                        Message = $"Dear {customer.Name},\n\nYour account has been successfully created.\n\nBest regards,\nYour Company"
                    };

                    var content = new StringContent(JsonSerializer.Serialize(emailRequest), System.Text.Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("https://localhost:44358/api/email/send", content);

                    response.EnsureSuccessStatusCode();

                    await transaction.CommitAsync();

                    return Ok(customer);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
             
                    return StatusCode(500, new
                    {
                        message = "An error occurred while creating the customer.",
                        details = ex.Message
                    });
                }
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var customer = await _context.Customers
                .Include(c => c.CustomerJobs)
                .Include(c => c.CustomerRelations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            // Güncelleme işlemleri
            customer.Name = updatedCustomer.Name;
            customer.Surname = updatedCustomer.Surname;
            customer.CustomerType = updatedCustomer.CustomerType;
            customer.NetIncomeAmount = updatedCustomer.NetIncomeAmount;
            customer.TC = updatedCustomer.TC;

            // Mevcut işleri güncelle
            var existingJobs = customer.CustomerJobs.ToList();
            foreach (var job in updatedCustomer.CustomerJobs)
            {
                var existingJob = existingJobs.FirstOrDefault(j => j.Id == job.Id);
                if (existingJob != null)
                {
                    existingJob.CompanyName = job.CompanyName;
                    existingJob.StartDate = job.StartDate;
                    existingJob.EndDate = job.EndDate;
                    existingJob.Salary = job.Salary;
                    existingJob.Position = job.Position;
                }
                else
                {
                    customer.CustomerJobs.Add(job);
                }
            }

            // Silinmiş olan işleri kaldır
            var jobsToRemove = existingJobs.Where(j => !updatedCustomer.CustomerJobs.Any(uj => uj.Id == j.Id)).ToList();
            _context.CustomerJobs.RemoveRange(jobsToRemove);

            // Mevcut ilişkileri güncelle
            var existingRelations = customer.CustomerRelations.ToList();
            foreach (var relation in updatedCustomer.CustomerRelations)
            {
                var existingRelation = existingRelations.FirstOrDefault(r => r.Id == relation.Id);
                if (existingRelation != null)
                {
                    existingRelation.RelationType = relation.RelationType;
                    existingRelation.RelatedPersonFullName = relation.RelatedPersonFullName;
                }
                else
                {
                    customer.CustomerRelations.Add(relation);
                }
            }

            // Silinmiş olan ilişkileri kaldır
            var relationsToRemove = existingRelations.Where(r => !updatedCustomer.CustomerRelations.Any(ur => ur.Id == r.Id)).ToList();
            _context.CustomerRelations.RemoveRange(relationsToRemove);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(customer);
        }


        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.CustomerJobs)
                .Include(c => c.CustomerRelations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.CustomerJobs.RemoveRange(customer.CustomerJobs);
            _context.CustomerRelations.RemoveRange(customer.CustomerRelations);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}




/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ATM_project.Services;
using ATMWithdrawalApi.Models;

namespace ATM_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public CustomerController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Model validation failed.",
                    errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
            }

            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

            if (string.IsNullOrEmpty(customer.Email))
            {
                return BadRequest("Customer email cannot be null or empty.");
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();

                    var emailRequest = new
                    {
                        ToEmail = customer.Email,
                        Subject = "Welcome to Our Service",
                        Message = $"Dear {customer.Name},\n\nYour account has been successfully created.\n\nBest regards,\nYour Company"
                    };

                    var content = new StringContent(JsonSerializer.Serialize(emailRequest), System.Text.Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("https://localhost:44358/api/email/send", content);

                    response.EnsureSuccessStatusCode();

                    await transaction.CommitAsync();

                    return Ok(customer);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    Console.WriteLine($"Error creating customer: {ex.Message}");
                    return StatusCode(500, new
                    {
                        message = "An error occurred while creating the customer.",
                        details = ex.Message
                    });
                }
            }
        }
    }
}*/
