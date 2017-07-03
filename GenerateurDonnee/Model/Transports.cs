using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Transports
    {
        public Transports()
        {
            Pays = new HashSet<Pays>();
        }

        public int Id { get; set; }
        public int Contenance { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Pays> Pays { get; set; }
    }
}
