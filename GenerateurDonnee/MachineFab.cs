using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    public delegate void BonbonsProduced(Bonbon bonbon);
    class MachineFab
    {
        public event BonbonsProduced BonbonsProduced;

        public string Nom { get; set; }
        public string Variante { get; set; }

        public int Cadence { get; set; }

        public int InstallDelay { get; set; }

        public List<Bonbon> Bonbons { get; set; }

        public bool InProduction { get; set; }

        private Bonbon actualBonbon;
        private int installDelayCompteur =0;

        public MachineFab()
        {
            Bonbons = new List<Bonbon>();
        }

        public void Execute()
        {
            if (installDelayCompteur == 0)
            {
                if (Bonbons.Count > 0)
                {
                    if (actualBonbon != null)
                    {
                        actualBonbon.Compteur--;
                        if (actualBonbon.Compteur == 0)
                        {
                            Bonbons.Remove(actualBonbon);
                            BonbonsProduced(actualBonbon);
                            InstallNextBonbon();
                        }
                    }
                    else
                    {
                        InstallNextBonbon();
                    }
                }
            }
            else
            {
                installDelayCompteur--;
            }
        }

        private void InstallNextBonbon()
        {
            if (Bonbons.Count > 0)
            {
                if (actualBonbon != null && actualBonbon.Reference.Produits.Equals(Bonbons.First().Reference.Produits))
                {
                    actualBonbon = Bonbons.First();
                }
                else
                {
                    installDelayCompteur = InstallDelay * 60;
                    actualBonbon = Bonbons.First();
                    Console.WriteLine("Délai de " + installDelayCompteur + "s sur " + Nom);
                }
                InProduction = true;
            }
            else
            {
                actualBonbon = null;
                InProduction = false;
            }

        }

        internal void AddBonbons(LignesCommande item)
        {
            var bonbon = new Bonbon()
            {
                Commande = item,
                Reference = item.References,
                Quantite = item.Quantite,
                Compteur = item.Quantite * 3600 / Cadence 
            };
            Bonbons.Add(bonbon);
            InProduction = true;
        }
    }
}
