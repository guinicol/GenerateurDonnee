using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class Produits
    {
        public int Id { get; set; }
        public int Additifs { get; set; }
        public int Aromes { get; set; }
        public int CountCond { get; set; }
        public int CountFab { get; set; }
        public int Enrobages { get; set; }
        public int FraisExp { get; set; }
        public int FraisGen { get; set; }
        public int Gelifiants { get; set; }
        public string Nom { get; set; }
        public int Sucre { get; set; }
        public int Coef { get; set; }
    }
}
