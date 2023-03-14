using Microsoft.EntityFrameworkCore;

namespace Day9Lab2.Models
{
    public class Datacontext: Microsoft.EntityFrameworkCore.DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options) { }   
        public virtual DbSet<Customer> Customers { get; set; }  
    }
}
