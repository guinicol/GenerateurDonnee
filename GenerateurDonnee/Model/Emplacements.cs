using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Emplacements
    {
        public int Id { get; set; }
        public int IdGares { get; set; }
        public int? IdReferences { get; set; }
        public string Nom { get; set; }
        public int? Quantite { get; set; }

        public virtual Gares IdGaresNavigation { get; set; }
        public virtual References IdReferencesNavigation { get; set; }
    }
}
