using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class ContenuCartons
    {
        public int Id { get; set; }
        public int IdCartons { get; set; }
        public int IdReferences { get; set; }
        public int Quantite { get; set; }

        public virtual Cartons IdCartonsNavigation { get; set; }
        public virtual References IdReferencesNavigation { get; set; }
    }
}
