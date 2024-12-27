using GestionCommandes.Core.Entities;

namespace GestionCommandes.Services
{
    public interface ICommandeService
    {
        Task<List<Commande>> GetCommandesAsync();
        Task<Commande> GetCommandeByIdAsync(int id);
    }
}