using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Commandes
    {
        public Commandes()
        {
            Cartons = new HashSet<Cartons>();
            LignesCommande = new HashSet<LignesCommande>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateExpedition { get; set; }
        public DateTime? DateProduction { get; set; }
        public int Etat { get; set; }
        public int IdPays { get; set; }

        public virtual ICollection<Cartons> Cartons { get; set; }
        public virtual ICollection<LignesCommande> LignesCommande { get; set; }
        public virtual Pays IdPaysNavigation { get; set; }
    }
}
