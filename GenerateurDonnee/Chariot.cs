using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateurDonnee
{
    class Chariot
    {
        public Cartons Carton { get; set; }
        public Dictionary<int, int> ShoppingList { get; set; }
        public int Compteur { get; set; }
        public int IdGares { get; set; }
        public Commandes Commande { get; set; }
        public int Poids { get; set; }
        public bool InGare { get; set; }


    }
}
