using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Cartons
    {
        public Cartons()
        {
            ContenuCartons = new HashSet<ContenuCartons>();
        }

        public int Id { get; set; }
        public int IdCommandes { get; set; }

        public virtual ICollection<ContenuCartons> ContenuCartons { get; set; }
        public virtual Commandes IdCommandesNavigation { get; set; }
    }
}
