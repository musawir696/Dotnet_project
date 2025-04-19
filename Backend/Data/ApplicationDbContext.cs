using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    // Define the application's DbContext, which will be used to interact with the database
    public class ApplicationDbContext : DbContext  
    {
        // Constructor that accepts DbContextOptions to configure the context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { 
        }

        // DbSet representing the collection of Customer entities in the database
        public DbSet<Customer> Customers { get; set; }
    }
}
