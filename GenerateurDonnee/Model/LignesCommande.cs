﻿using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class LignesCommande
    {
        public int Id { get; set; }
        public int Etat { get; set; }
        public int IdCommandes { get; set; }
        public int IdReferences { get; set; }
        public int Quantite { get; set; }

        public virtual Commandes IdCommandesNavigation { get; set; }
        public virtual References IdReferencesNavigation { get; set; }
    }
}
