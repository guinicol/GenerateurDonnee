using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    public delegate void PackageProduced(Emballage package);
    class MachineCond
    {
        public event PackageProduced PackageProduced;
        public string Nom { get; set; }

        public string Packaging { get; set; }

        public int Cadence { get; set; }

        public int InstallDelay { get; set; }

        public List<Emballage> Packages { get; set; }

        public bool InProduction { get; set; }

        private Emballage actualpackage;
        private int installDelayCompteur = 0;

        public MachineCond()
        {
            Packages = new List<Emballage>();
        }

        public void Execute()
        {
            if (installDelayCompteur == 0)
            {
                if (Packages.Count > 0)
                {
                    if (actualpackage != null)
                    {
                        actualpackage.Compteur--;
                        if (actualpackage.Compteur == 0)
                        {
                            Packages.Remove(actualpackage);
                            PackageProduced(actualpackage);
                            InstallNextPackage();
                        }
                    }
                    else
                    {
                        InstallNextPackage();
                    }
                }
            }
            else
            {
                installDelayCompteur--;
            }
        }
        private void InstallNextPackage()
        {
            if (Packages.Count > 0)
            {
                if (actualpackage != null && actualpackage.Reference.Produits.Equals(Packages.First().Reference.Produits))
                {
                    actualpackage = Packages.First();
                }
                else
                {
                    installDelayCompteur = InstallDelay * 60;
                    actualpackage = Packages.First();
                    Console.WriteLine("Délai de " + installDelayCompteur + "s sur " + Nom);
                }
                InProduction = true;
            }
            else
            {
                actualpackage = null;
                InProduction = false;
            }

        }
        public void AddPackage(LignesCommande item)
        {
            var package = new Emballage()
            {
                Commande = item,
                Reference = item.References,
                Quantite = item.Quantite,

            };
            package.Compteur = package.Quantite * 3600 / Cadence;
            Packages.Add(package);
            InProduction = true;
        }
    }
}
