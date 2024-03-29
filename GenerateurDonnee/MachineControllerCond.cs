﻿using Microsoft.EntityFrameworkCore;
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
        private int compteurVerifCommande=0;

        public MachineControllerCond(projetbiContext context)
        {
            this.context = context;
            Machines = new List<MachineCond>();
            var machine1 = new MachineCond()
            {
                Nom = "machine1",
                Packaging = "Sachet",
                Cadence = 500,
                InstallDelay = 15
            };
            machine1.PackageProduced += PackageProducedHandler;
            Machines.Add(machine1);
            var machine2 = new MachineCond()
            {
                Nom = "machine2",
                Packaging = "Sachet",
                Cadence = 500,
                InstallDelay = 15
            };
            machine2.PackageProduced += PackageProducedHandler;
            Machines.Add(machine2);
            var machine3 = new MachineCond()
            {
                Nom = "machine3",
                Packaging = "Sachet",
                Cadence = 750,
                InstallDelay = 25
            };
            machine3.PackageProduced += PackageProducedHandler;
            Machines.Add(machine3);
            var machine4 = new MachineCond()
            {
                Nom = "machine4",
                Packaging = "Boite",
                Cadence = 200,
                InstallDelay = 10
            };
            machine4.PackageProduced += PackageProducedHandler;
            Machines.Add(machine4);
            var machine5 = new MachineCond()
            {
                Nom = "machine5",
                Packaging = "Boite",
                Cadence = 200,
                InstallDelay = 10
            };
            machine5.PackageProduced += PackageProducedHandler;
            Machines.Add(machine5);
            var machine6 = new MachineCond()
            {
                Nom = "machine6",
                Packaging = "Echantillon",
                Cadence = 150,
                InstallDelay = 15
            };
            machine6.PackageProduced += PackageProducedHandler;
            Machines.Add(machine6);
        }


        public void Execute()
        {
            if (compteurVerifCommande == 0)
            {
                var lignesCommande = context.LignesCommande
                .Include((x) => x.IdReferencesNavigation)
                .Include((x) => x.IdReferencesNavigation.IdVariantesNavigation)
                .Include((x) => x.IdReferencesNavigation.IdConditionnementsNavigation)
                .Where((x) => x.Etat == 3).ToList();
                foreach (var item in lignesCommande)
                {
                    foreach (var machine in Machines)
                    {
                        if (!machine.InProduction && machine.Packaging.Equals(item.IdReferencesNavigation.IdConditionnementsNavigation.Nom))
                        {
                            machine.AddPackage(item);
                            item.Etat = 4;
                            Console.WriteLine("Référence " + item.IdReferencesNavigation.Id + " " + item.IdReferencesNavigation.IdConditionnementsNavigation.Nom + " conditionné dans " + machine.Nom);
                            break;
                        }
                    }
                    if (item.Etat == 3)
                    {
                        foreach (var machine in Machines)
                        {
                            if (machine.Packaging.Equals(item.IdReferencesNavigation.IdConditionnementsNavigation.Nom))
                            {
                                machine.AddPackage(item);
                                item.Etat = 4;
                                Console.WriteLine("Référence " + item.IdReferencesNavigation.Id + " " + item.IdReferencesNavigation.IdConditionnementsNavigation.Nom + " en attente dans " + machine.Nom);
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
        private void PackageProducedHandler(Emballage package)
        {
            Console.WriteLine("Ligne Commande " + package.Commande.Id + "(Commande "+ package.Commande.IdCommandes+") Reference " + package.Commande.IdReferences + " emballer");
            package.Commande.Etat = 5;
            var Commandes = context.Commandes.Include((x) => x.LignesCommande).Where((x) => x.Id == package.Commande.IdCommandes).First();
            if (!Commandes.LignesCommande.Any((x) => x.Etat != 5))
            {
                Commandes.Etat = 3;
                Commandes.DateProduction = Program.Date;
                Console.WriteLine("Commande " + Commandes.Id + " terminee");
            }
            var emplacements = context.Emplacements.SingleOrDefault((x) => x.IdReferences == package.Reference.Id);
            if(emplacements != null)
            {
                emplacements.Quantite += package.Quantite;
                Console.WriteLine("Ajout quantite a Emplacement n" + emplacements.Id);
            }
            else
            {
                var list = context.Emplacements.Where((x) => x.IdReferences == null).ToList();
                var random = new Random();
                emplacements = list[random.Next(0,list.Count)];
                emplacements.IdReferences = package.Reference.Id;
                emplacements.Quantite = package.Quantite;
                Console.WriteLine("Ajout quantite et Reference a Emplacement n" + emplacements.Id);

            }
            context.SaveChanges();
        }

    }
}
