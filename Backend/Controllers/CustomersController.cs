using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;  

        
        public CustomersController(ApplicationDbContext context)  
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {

            return await _context.Customers.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            // Find the customer by ID
            var customer = await _context.Customers.FindAsync(id);

            // Return NotFound if customer is not found
            return customer == null ? NotFound() : customer;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            // Add the new customer to the context
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

       
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            // Check if the ID matches the customer
            if (id != customer.Id)
                return BadRequest();

            // Update the customer in the context
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!CustomerExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            // Find the customer by ID
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            // Remove the customer and save changes
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if a customer exists
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
