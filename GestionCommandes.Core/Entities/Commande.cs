namespace GestionCommandes.Core.Entities
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<CommandeProduit> CommandeProduits { get; set; } = new List<CommandeProduit>();
        public EtatCommande Etat { get; set; } // Enum pour suivre l'état
    }
}