using Microsoft.EntityFrameworkCore;

namespace WebAPiKiller.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //MyData
        public DbSet<Killer> Killers { get; set; }
    }
}
