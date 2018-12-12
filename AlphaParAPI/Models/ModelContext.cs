using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlphaParAPI.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Piece> Piece { get; set; }
        public DbSet<ProductionChain> ProductionChain { get; set; }

        public DbSet<Command> Command { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PieceProductionChain>()
                .HasKey(t => new { t.IdPiece, t.IdProductionChain});

            modelBuilder.Entity<PieceProductionChain>()
                .HasOne(pt => pt.Piece)
                .WithMany(p => p.PieceProductionChains)
                .HasForeignKey(pt => pt.IdPiece);

            modelBuilder.Entity<PieceProductionChain>()
                .HasOne(pt => pt.ProductionChain)
                .WithMany(t => t.PieceProductionChains)
                .HasForeignKey(pt => pt.IdProductionChain);
        }

    }
}
