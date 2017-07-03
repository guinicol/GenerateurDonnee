using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    public delegate void LigneCommandeProduced(LignesCommande lignesCommande);
    class MachineControllerFab
    {
        public event LigneCommandeProduced LigneCommandeProduced;
        public List<MachineFab> Machines { get; set; }
        private projetbiContext context;

        private int compteurVerifCommande = 0;
        public MachineControllerFab(projetbiContext context)
        {
            this.context = context;
            Machines = new List<MachineFab>();
            var machine1 = new MachineFab()
            {
                Nom = "machine1",
                Cadence = 750,
                InstallDelay = 25,
                Variante = "Acide"
            };
            machine1.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine1);
            var machine2 = new MachineFab()
            {
                Nom = "machine2",
                Cadence = 1230,
                InstallDelay = 45,
                Variante = "Sucré"
            };
            machine2.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine2);
            var machine3 = new MachineFab()
            {
                Nom = "machine3",
                Cadence = 625,
                InstallDelay = 25,
                Variante = "Gélifié"
            };
            machine3.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine3);
            var machine4 = new MachineFab()
            {
                Nom = "machine4",
                Cadence = 1230,
                InstallDelay = 45,
                Variante = "Sucré"
            };
            machine4.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine4);
        }

        public void Execute()
        {
            if (compteurVerifCommande == 0)
            {
                var lignesCommande = context.LignesCommande
                    .Include((x)=>x.IdCommandesNavigation)
                    .Include((x) => x.IdReferencesNavigation)
                    .Include((x) => x.IdReferencesNavigation.IdVariantesNavigation)
                    .Include((x) => x.IdReferencesNavigation.IdConditionnementsNavigation)
                    .Where((x) => x.Etat == 1).ToList();
                foreach (var item in lignesCommande)
                {
                    foreach (var machine in Machines)
                    {
                        if (!machine.InProduction && machine.Variante.Equals(item.IdReferencesNavigation.IdVariantesNavigation.Nom))
                        {
                            machine.AddBonbons(item);
                            item.Etat = 2;
                            item.IdCommandesNavigation.Etat = 2;
                            Console.WriteLine("Référence " + item.IdReferencesNavigation.Id +" fabriqué dans " + machine.Nom);
                            break;
                        }
                    }
                    if (item.Etat == 1)
                    {
                        foreach (var machine in Machines)
                        {
                            if (machine.Variante.Equals(item.IdReferencesNavigation.IdVariantesNavigation.Nom))
                            {
                                machine.AddBonbons(item);
                                item.Etat = 2;
                                item.IdCommandesNavigation.Etat = 2;
                                Console.WriteLine("Référence " + item.IdReferencesNavigation.Id + " en attente dans " + machine.Nom);
                                break;
                            }
                        }
                    }
                }
                context.SaveChanges();
                compteurVerifCommande = 60;
            }
            else
            {
                compteurVerifCommande--;
            }

            foreach (var item in Machines)
            {
                item.Execute();
            }
        }

        private void BonbonsProducedHandler(Bonbon bonbon)
        {
            Console.WriteLine("Ligne Commande " + bonbon.Commande.Id + "(Commande " + bonbon.Commande.IdCommandes + ") Reference " + bonbon.Commande.IdReferences + " produite");
            bonbon.Commande.Etat = 3;
            context.SaveChanges();
        }
    }
}
