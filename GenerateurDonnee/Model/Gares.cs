using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Gares
    {
        public Gares()
        {
            Emplacements = new HashSet<Emplacements>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Emplacements> Emplacements { get; set; }
    }
}
