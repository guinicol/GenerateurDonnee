using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateurDonnee
{
    class MachineCond
    {
        public string Nom { get; set; }

        public string Variante { get; set; }

        public int Cadence { get; set; }

        public int InstallDelay { get; set; }

        public List<Emballage> Bonbons { get; set; }

        public bool InProduction { get; set; }

        private Bonbon actualBonbon;
        private int installDelayCompteur = 0;

        public void Execute()
        {

        }
        public void AddBonbons(LignesCommande ligne)
        {

        }
    }
}
