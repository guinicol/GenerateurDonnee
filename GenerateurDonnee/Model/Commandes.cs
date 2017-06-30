using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GenerateurDonnee
{
    public partial class Commandes
    {
        [Key]
        public int Id { get; set; }

        public Pays Pays { get; set; }
        [ForeignKey("Pays")]
        public int IdPays { get; set; }

        public DateTime Date { get; set; }

        public ICollection<LignesCommande> LignesCommandes { get; set; }
    }
}
