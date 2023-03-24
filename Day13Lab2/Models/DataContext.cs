using Microsoft.EntityFrameworkCore;
namespace Day13Lab2.Models {
    public class DataContext :DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Tables
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }
    }
}
