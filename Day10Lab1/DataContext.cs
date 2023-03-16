using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Day10Lab1c;

namespace Day10Lab1 {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
