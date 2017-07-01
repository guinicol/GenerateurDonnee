using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateurDonnee
{
    class CommandRandomiser
    {
        public projetbiContext Context { get; set; }
        public Commandes GetCommande()
        {
            var Commande = new Commandes()
            {
                Date = Program.Date,
                Etat = 1
            };
            Commande.Pays = GetPays();
            Commande.LignesCommandes = GetLignesCommandes();

            return Commande;
        }

        private ICollection<LignesCommande> GetLignesCommandes()
        {
            var list = new List<LignesCommande>();
            var random = new Random();

            int max = random.Next(1, 6);
            for (int i = 0; i < max; i++)
            {
                var ligne = new LignesCommande()
                {
                    Etat = 1,
                    References = getReference(list),
                    Quantite = random.Next(5, 21)
                };
                list.Add(ligne);
            }

            return list;
        }

        private References getReference(List<LignesCommande> list)
        {
            var random = new Random();
            var i = random.Next(1,3);
            var cond = Context.Conditionnements.Where((x) => x.Id == i).First();
            i = random.Next(1, Context.Textures.Count()+1);
            var text = Context.Textures.Where((x) => x.Id == i).First();
            i = random.Next(1, Context.Variantes.Count()+1);
            var variante = Context.Variantes.Where((x) => x.Id == i).First();
            i = random.Next(1, Context.Couleurs.Count()+1);
            var col = Context.Couleurs.Where((x) => x.Id == i).First();

            var prod = GetProduits(list);

            return Context.References.Where((x) => x.IdConditionnements == cond.Id
            && x.IdCouleurs == col.Id
            && x.IdTextures == text.Id
            && x.IdVariantes == variante.Id
            && x.IdProduits == prod.Id).First();

        }

        private Produits GetProduits(List<LignesCommande> list)
        {
            var listProd = Context.Produits.Where((x) => true).ToList();
            var listCoef = new List<int>();
            foreach (var item in listProd)
            {
                if (!list.Any((x) => x.Id == item.Id))
                {
                    for (int i = 0; i < item.Coef; i++)
                    {
                        listCoef.Add(item.Id);
                    }
                }
            }
            var random = new Random();
            var y = random.Next(0, listCoef.Count);
            return listProd.Where((x) => x.Id == listCoef[y]).First();
        }

        private Pays GetPays()
        {
            var listPays = Context.Pays.Where((x) => true).ToList();
            var listCoef = new List<int>();
            foreach (var item in listPays)
            {
                for (int i = 0; i < item.Coef; i++)
                {
                    listCoef.Add(item.Id);
                }
            }
            var random = new Random();
            var y = random.Next(0, listCoef.Count);
            return listPays.Where((x) => x.Id == listCoef[y]).First();


        }
    }
}
