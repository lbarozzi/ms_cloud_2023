using Microsoft.EntityFrameworkCore;

namespace Day13Lab1.Models {
    public class MyDbContext: DbContext  {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }   

        public virtual DbSet<Anagraphic> Anagraphics { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

    }
}
