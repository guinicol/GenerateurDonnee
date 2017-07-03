using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Textures
    {
        public Textures()
        {
            References = new HashSet<References>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<References> References { get; set; }
    }
}
