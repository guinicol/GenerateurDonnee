using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class LignesCommande
    {
        public int Id { get; set; }
        public int IdCommandes { get; set; }
        public int IdReferences { get; set; }
        public int Quantite { get; set; }
    }
}
