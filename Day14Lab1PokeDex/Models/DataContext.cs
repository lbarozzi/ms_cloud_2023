using Microsoft.EntityFrameworkCore;

namespace Day14Lab1PokeDex.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Tables
        public virtual DbSet<Pokemon> Pokemons { get; set; }
        public virtual DbSet<Element> Elements { get; set; }    
        public virtual DbSet<ElementSensibility> ElementsSensibilities { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Move> Moves { get; set; }

    }
}
