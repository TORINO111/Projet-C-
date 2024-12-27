namespace GestionCommandes.Core.Entities
{
    public class CommandeProduit
    {
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

        public int Quantite { get; set; }
    }
}