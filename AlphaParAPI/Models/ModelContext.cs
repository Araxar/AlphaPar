using Microsoft.EntityFrameworkCore;

namespace AlphaParAPI.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        // Déclaration des différentes tables de la base 
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Piece> Piece { get; set; }
        public DbSet<ProductionChain> ProductionChain { get; set; }
        public DbSet<Command> Command { get; set; }

    }
}
