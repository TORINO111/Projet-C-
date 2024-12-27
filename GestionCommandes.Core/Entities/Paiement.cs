namespace GestionCommandes.Core.Entities
{
    public class Paiement
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        public string TypePaiement { get; set; }
        public decimal Montant { get; set; }
        public string Reference { get; set; }
    }
}