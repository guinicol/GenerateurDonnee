using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Couleurs
    {
        public Couleurs()
        {
            References = new HashSet<References>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<References> References { get; set; }
    }
}
