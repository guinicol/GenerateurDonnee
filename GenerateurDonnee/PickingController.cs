using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    class PickingController : IAction
    {
        private int compteurVerifCommande;

        public projetbiContext Context { get; set; }
        public List<Chariot> Chariots { get; set; }
        public List<Gares> Gares { get; set; }
        public PickingController(projetbiContext context)
        {
            Context = context;
            Chariots = new List<Chariot>();
        }
        public void Execute()
        {
            if (compteurVerifCommande == 0)
            {
                Gares = Context.Gares.Include((x) => x.Emplacements).ToList();
                var listCommandes = Context.Commandes
                .Include((x) => x.LignesCommande)
                .ThenInclude((x) => x.IdReferencesNavigation.IdConditionnementsNavigation)
                .Where((x) => x.Etat == 3).ToList();
                foreach (var item in listCommandes)
                {

                    var chariot = new Chariot()
                    {
                        Carton = new Cartons(),
                        Commande = item,
                        ShoppingList = new Dictionary<int, int>(),
                        Compteur = 60 * 8
                    };
                    Chariots.Add(chariot);
                    foreach (var ligne in item.LignesCommande)
                    {
                        var poids = ligne.Quantite * ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton;

                        if (Chariots.Last().Poids + poids <= 200)
                        {
                            Chariots.Last().ShoppingList.Add(ligne.IdReferences, ligne.Quantite);
                            Chariots.Last().Poids += poids;

                        }
                        else if (Chariots.Last().Poids <= 200)
                        {
                            var qte = (200 - Chariots.Last().Poids) / ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton;
                            if (qte > 0)
                            {
                                Chariots.Last().ShoppingList.Add(ligne.IdReferences, qte);
                                Chariots.Last().Poids += qte * ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton;
                            }
                            qte = ligne.Quantite - qte;
                            do
                            {
                                var chariot2 = new Chariot()
                                {
                                    Carton = new Cartons(),
                                    Commande = item,
                                    ShoppingList = new Dictionary<int, int>(),
                                    Compteur = 60 * 8

                                };
                                var qte2 = 0;
                                if (qte * ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton > 200)
                                {
                                    qte2 = 200 / ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton;

                                }
                                else
                                {
                                    qte2 = qte;
                                }
                                chariot2.ShoppingList.Add(ligne.IdReferences, qte2);
                                chariot2.Poids += qte2 * ligne.IdReferencesNavigation.IdConditionnementsNavigation.PoidsCarton;
                                Chariots.Add(chariot2);
                                qte -= qte2;
                            } while (qte > 0);
                        }


                    }
                    item.Etat++;
                }
                compteurVerifCommande = 60;
            }
            else
            {
                compteurVerifCommande--;
            }
            foreach (var item in Chariots)
            {
                item.Compteur--;
                if (item.Compteur == 0)
                {
                    if (item.InGare)
                    {
                        item.InGare = false;
                        item.Compteur = 8 * 60;
                    }
                    else
                    {
                        item.IdGares++;
                        if (item.IdGares > Gares.Count)
                        {
                            item.Carton.IdCommandesNavigation = item.Commande;
                            Context.Cartons.Add(item.Carton);
                            item.Commande.DateExpedition = Program.Date;
                            Console.WriteLine("Carton emballé Commande " + item.Commande.Id);
                        }
                        else
                        {
                            if (Chariots.Count((x) => x.IdGares == item.IdGares) <= 7)
                            {
                                var gare = Gares.Single((x) => x.Id == item.IdGares);
                                var tmp = item.ShoppingList.ToList();
                                Console.WriteLine("Carton dans Gare " + gare.Nom + " Commande" + item.Commande.Id);
                                foreach (var shopping in tmp)
                                {
                                    if (gare != null && gare.Emplacements.Any((x) => x.IdReferences == shopping.Key))
                                    {
                                        var contenuCarton = new ContenuCartons()
                                        {
                                            IdReferences = shopping.Key,
                                            Quantite = shopping.Value
                                        };
                                        item.Carton.ContenuCartons.Add(contenuCarton);
                                        item.ShoppingList.Remove(shopping.Key);
                                        gare.Emplacements.Where((x) => x.IdReferences == shopping.Key).First().Quantite -= shopping.Value;
                                        item.InGare = true;
                                    }

                                }
                                if (item.InGare)
                                {
                                    item.Compteur = 17 * 60;
                                }
                                else
                                {
                                    item.Compteur = 8 * 60;
                                }
                            }
                            else
                            {
                                item.IdGares--;
                                item.Compteur++;
                            }
                        }
                    }
                }
            }
            Context.SaveChanges();
        }
    }
}
