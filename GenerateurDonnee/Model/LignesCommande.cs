using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenerateurDonnee
{
    public partial class LignesCommande
    {
        [Key]
        public int Id { get; set; }
        public Commandes Commandes { get; set; }
        [ForeignKey("Commandes")]
        public int IdCommandes { get; set; }
        [ForeignKey("References")]
        public int IdReferences { get; set; }
        public References References { get; set; }
        public int Quantite { get; set; }

        public int Etat { get; set; }
    }
}
