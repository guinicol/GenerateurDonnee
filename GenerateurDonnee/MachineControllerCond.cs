using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    class MachineControllerCond
    {
        private List<MachineCond> Machines;
        private projetbiContext context;

        public MachineControllerCond(projetbiContext context)
        {
            this.context = context;
            Machines = new List<MachineCond>();
            var machine1 = new MachineCond();
            Machines.Add(machine1);
        }

        public void Execute()
        {
            var lignesCommande = context.LignesCommande
                .Include((x) => x.References)
                .Include((x) => x.References.Variantes)
                .Include((x) => x.References.Conditionnements)
                .Where((x) => x.Etat == 3).ToList();
            foreach (var item in lignesCommande)
            {
                foreach (var machine in Machines)
                {
                    if (!machine.InProduction && machine.Variante.Equals(item.References.Conditionnements.Nom))
                    {
                        machine.AddBonbons(item);
                        item.Etat++;
                        Console.WriteLine("Référence " + item.References.Produits.Nom + " " + item.References.Conditionnements.Nom + " conditionné dans " + machine.Nom);
                    }
                }
                if (item.Etat == 1)
                {
                    foreach (var machine in Machines)
                    {
                        if (machine.Variante.Equals(item.References.Conditionnements.Nom))
                        {
                            machine.AddBonbons(item);
                            item.Etat++;
                            Console.WriteLine("Référence " + item.References.Produits.Nom + " " + item.References.Conditionnements.Nom + " en attente dans " + machine.Nom);

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

    }
}
