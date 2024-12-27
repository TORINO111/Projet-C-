using GestionCommandes.Core.Entities;
using GestionCommandes.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCommandes.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly GestionCommandesContext _context;

        public CommandeService(GestionCommandesContext context)
        {
            _context = context;
        }

        public async Task<List<Commande>> GetCommandesAsync()
        {
            return await _context.Commandes
                .Include(c => c.Client)
                .Include(c => c.CommandeProduits)
                .ThenInclude(cp => cp.Produit)
                .ToListAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int id)
        {
            return await _context.Commandes
                .Include(c => c.Client)
                .Include(c => c.CommandeProduits)
                .ThenInclude(cp => cp.Produit)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}