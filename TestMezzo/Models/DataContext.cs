using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.EntityFrameworkCore;

namespace TestMezzo.Models {
    public class DataContext :DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }   


        public virtual DbSet<Taxi> Taxis { get; set; }
        public virtual DbSet<Corsa> Corse { get; set; }
    }
}
