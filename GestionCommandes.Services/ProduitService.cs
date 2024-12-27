using GestionCommandes.Core.Entities;
using GestionCommandes.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCommandes.Services
{
    public class ProduitService : IProduitService
    {
        private readonly GestionCommandesContext _context;

        public ProduitService(GestionCommandesContext context)
        {
            _context = context;
        }

        public async Task<List<Produit>> GetProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit> GetProduitByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        public async Task AddProduitAsync(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduitAsync(Produit produit)
        {
            _context.Entry(produit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }
    }
}