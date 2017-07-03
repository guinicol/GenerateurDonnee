using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Pays
    {
        public Pays()
        {
            Commandes = new HashSet<Commandes>();
        }

        public int Id { get; set; }
        public int Coef { get; set; }
        public int IdTransports { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Commandes> Commandes { get; set; }
        public virtual Transports IdTransportsNavigation { get; set; }
    }
}
