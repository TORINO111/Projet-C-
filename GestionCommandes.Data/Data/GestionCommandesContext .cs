using GestionCommandes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionCommandes.Data.Data
{
    public class GestionCommandesContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeProduit> CommandeProduits { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

        public GestionCommandesContext(DbContextOptions<GestionCommandesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurer les relations
            modelBuilder.Entity<CommandeProduit>()
                .HasKey(cp => new { cp.CommandeId, cp.ProduitId });

            modelBuilder.Entity<CommandeProduit>()
                .HasOne(cp => cp.Commande)
                .WithMany(c => c.CommandeProduits)
                .HasForeignKey(cp => cp.CommandeId);

            modelBuilder.Entity<CommandeProduit>()
                .HasOne(cp => cp.Produit)
                .WithMany()
                .HasForeignKey(cp => cp.ProduitId);

            base.OnModelCreating(modelBuilder);
        }
    }
}