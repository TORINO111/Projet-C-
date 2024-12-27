namespace GestionCommandes.Core.Entities
{
    public class Livraison
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        public DateTime DateLivraison { get; set; }
        public string AdresseLivraison { get; set; }
        public int LivreurId { get; set; }
        public Livreur Livreur { get; set; }
    }
}