using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenerateurDonnee
{
    public partial class References
    {
        public int Id { get; set; }
        public int IdConditionnements { get; set; }
        [ForeignKey("IdConditionnements")]
        public Conditionnements Conditionnements { get; set; }
        public int IdCouleurs { get; set; }
        [ForeignKey("IdCouleurs")]
        public Couleurs Couleurs { get; set; }
        public int IdProduits { get; set; }
        [ForeignKey("IdProduits")]
        public Produits Produits { get; set; }
        public int IdTextures { get; set; }
        [ForeignKey("IdTextures")]
        public Textures Textures { get; set; }
        public int IdVariantes { get; set; }
        [ForeignKey("IdVariantes")]
        public Variantes Variantes { get; set; }
        public float Prix { get; set; }
    }
}
