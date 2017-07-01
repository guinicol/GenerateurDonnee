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
                Cadence = 25,
                InstallDelay = 625,
                Variante = "Gélifié"
            };
            machine3.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine3);
            var machine4 = new MachineFab()
            {
                Nom = "machine4",
                Cadence = 25,
                InstallDelay = 625,
                Variante = "Gélifié"
            };
            machine4.BonbonsProduced += BonbonsProducedHandler;
            Machines.Add(machine4);
        }

        public void Execute()
        {
            var lignesCommande = context.LignesCommande
                .Include((x)=> x.References)
                .Include((x)=>x.References.Variantes)
                .Where((x) => x.Etat == 1).ToList();
            foreach (var item in lignesCommande)
            {
                foreach (var machine in Machines)
                {
                    if (!machine.InProduction && machine.Variante.Equals(item.References.Variantes.Nom))
                    {
                        machine.AddBonbons(item);
                        item.Etat++;
                        Console.WriteLine("Référence " + item.References.Produits.Nom + " " + item.References.Variantes.Nom + " fabriqué dans " + machine.Nom);
                    }
                }
                if (item.Etat == 1)
                {
                    foreach (var machine in Machines)
                    {
                        if (machine.Variante.Equals(item.References.Variantes.Nom))
                        {
                            machine.AddBonbons(item);
                            item.Etat++;
                            Console.WriteLine("Référence " + item.References.Produits.Nom + " " + item.References.Variantes.Nom + " en attente dans " + machine.Nom);

                        }
                    }
                }
            }
            context.SaveChanges();
            foreach (var item in Machines)
            {
                item.Execute();
            }
        }

        private void BonbonsProducedHandler(Bonbon bonbon)
        {
            Console.WriteLine("Commande " + bonbon.Commande.Id + " Reference " + bonbon.Commande.IdReferences + " produite");
            bonbon.Commande.Etat++;
            context.SaveChanges();
        }
    }
}
