using Microsoft.EntityFrameworkCore;

namespace Day19Lab1.Models {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) :base(options) { 
        }

        //
        public virtual DbSet<Customer> Customers { get; set; }  
    }
}
