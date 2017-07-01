namespace GenerateurDonnee
{
    public class Emballage
    {
        public References Reference { get; set; }
        public int Quantite { get; set; }

        public int Compteur { get; set; }
        public LignesCommande Commande { get; set; }
    }
}