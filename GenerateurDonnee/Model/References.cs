using System;
using System.Collections.Generic;

namespace GenerateurDonnee
{
    public partial class References
    {
        public References()
        {
            ContenuCartons = new HashSet<ContenuCartons>();
            Emplacements = new HashSet<Emplacements>();
            LignesCommande = new HashSet<LignesCommande>();
        }

        public int Id { get; set; }
        public int IdConditionnements { get; set; }
        public int IdCouleurs { get; set; }
        public int IdProduits { get; set; }
        public int IdTextures { get; set; }
        public int IdVariantes { get; set; }
        public float Prix { get; set; }

        public virtual ICollection<ContenuCartons> ContenuCartons { get; set; }
        public virtual ICollection<Emplacements> Emplacements { get; set; }
        public virtual ICollection<LignesCommande> LignesCommande { get; set; }
        public virtual Conditionnements IdConditionnementsNavigation { get; set; }
        public virtual Couleurs IdCouleursNavigation { get; set; }
        public virtual Produits IdProduitsNavigation { get; set; }
        public virtual Textures IdTexturesNavigation { get; set; }
        public virtual Variantes IdVariantesNavigation { get; set; }
    }
}
