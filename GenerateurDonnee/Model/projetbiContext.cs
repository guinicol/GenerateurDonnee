using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GenerateurDonnee
{
    public partial class projetbiContext : DbContext
    {
        public virtual DbSet<Cartons> Cartons { get; set; }
        public virtual DbSet<Commandes> Commandes { get; set; }
        public virtual DbSet<Conditionnements> Conditionnements { get; set; }
        public virtual DbSet<ContenuCartons> ContenuCartons { get; set; }
        public virtual DbSet<Couleurs> Couleurs { get; set; }
        public virtual DbSet<Emplacements> Emplacements { get; set; }
        public virtual DbSet<Gares> Gares { get; set; }
        public virtual DbSet<LignesCommande> LignesCommande { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<References> References { get; set; }
        public virtual DbSet<Textures> Textures { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }
        public virtual DbSet<Variantes> Variantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"Server=macharius40.tk;User Id=projetbi;Password=projetbi;Database=projetbi");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartons>(entity =>
            {
                entity.HasIndex(e => e.IdCommandes)
                    .HasName("idCommandes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCommandes)
                    .HasColumnName("idCommandes")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCommandesNavigation)
                    .WithMany(p => p.Cartons)
                    .HasForeignKey(d => d.IdCommandes)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Cartons_ibfk_1");
            });

            modelBuilder.Entity<Commandes>(entity =>
            {
                entity.HasIndex(e => e.IdPays)
                    .HasName("idPays");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateExpedition)
                    .HasColumnName("dateExpedition")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateProduction)
                    .HasColumnName("dateProduction")
                    .HasColumnType("datetime");

                entity.Property(e => e.Etat)
                    .HasColumnName("etat")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdPays)
                    .HasColumnName("idPays")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdPaysNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Commandes_ibfk_1");
            });

            modelBuilder.Entity<Conditionnements>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ContenuCartons>(entity =>
            {
                entity.HasIndex(e => e.IdCartons)
                    .HasName("idCartons");

                entity.HasIndex(e => e.IdReferences)
                    .HasName("idReferences");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCartons)
                    .HasColumnName("idCartons")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdReferences)
                    .HasColumnName("idReferences")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantite).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCartonsNavigation)
                    .WithMany(p => p.ContenuCartons)
                    .HasForeignKey(d => d.IdCartons)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ContenuCartons_ibfk_1");

                entity.HasOne(d => d.IdReferencesNavigation)
                    .WithMany(p => p.ContenuCartons)
                    .HasForeignKey(d => d.IdReferences)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ContenuCartons_ibfk_2");
            });

            modelBuilder.Entity<Couleurs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Emplacements>(entity =>
            {
                entity.HasIndex(e => e.IdGares)
                    .HasName("idGares");

                entity.HasIndex(e => e.IdReferences)
                    .HasName("idReferences");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGares)
                    .HasColumnName("idGares")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdReferences)
                    .HasColumnName("idReferences")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdGaresNavigation)
                    .WithMany(p => p.Emplacements)
                    .HasForeignKey(d => d.IdGares)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Emplacements_ibfk_1");

                entity.HasOne(d => d.IdReferencesNavigation)
                    .WithMany(p => p.Emplacements)
                    .HasForeignKey(d => d.IdReferences)
                    .HasConstraintName("Emplacements_ibfk_2");
            });

            modelBuilder.Entity<Gares>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<LignesCommande>(entity =>
            {
                entity.HasIndex(e => e.IdCommandes)
                    .HasName("idCommandes");

                entity.HasIndex(e => e.IdReferences)
                    .HasName("idReferences");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Etat)
                    .HasColumnName("etat")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdCommandes)
                    .HasColumnName("idCommandes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdReferences)
                    .HasColumnName("idReferences")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCommandesNavigation)
                    .WithMany(p => p.LignesCommande)
                    .HasForeignKey(d => d.IdCommandes)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("LignesCommande_ibfk_2");

                entity.HasOne(d => d.IdReferencesNavigation)
                    .WithMany(p => p.LignesCommande)
                    .HasForeignKey(d => d.IdReferences)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("LignesCommande_ibfk_1");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.HasIndex(e => e.IdTransports)
                    .HasName("idTransports");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Coef)
                    .HasColumnName("coef")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IdTransports)
                    .HasColumnName("idTransports")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.IdTransportsNavigation)
                    .WithMany(p => p.Pays)
                    .HasForeignKey(d => d.IdTransports)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Pays_ibfk_1");
            });

            modelBuilder.Entity<Produits>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Additifs)
                    .HasColumnName("additifs")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aromes)
                    .HasColumnName("aromes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Coef)
                    .HasColumnName("coef")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountCond)
                    .HasColumnName("countCond")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountFab)
                    .HasColumnName("countFab")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Enrobages)
                    .HasColumnName("enrobages")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FraisExp).HasColumnType("int(11)");

                entity.Property(e => e.FraisGen).HasColumnType("int(11)");

                entity.Property(e => e.Gelifiants)
                    .HasColumnName("gelifiants")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Sucre)
                    .HasColumnName("sucre")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<References>(entity =>
            {
                entity.HasIndex(e => e.IdConditionnements)
                    .HasName("idConditionnements");

                entity.HasIndex(e => e.IdCouleurs)
                    .HasName("idCouleurs");

                entity.HasIndex(e => e.IdProduits)
                    .HasName("idProduits");

                entity.HasIndex(e => e.IdTextures)
                    .HasName("idTextures");

                entity.HasIndex(e => e.IdVariantes)
                    .HasName("idVariantes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdConditionnements)
                    .HasColumnName("idConditionnements")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCouleurs)
                    .HasColumnName("idCouleurs")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProduits)
                    .HasColumnName("idProduits")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTextures)
                    .HasColumnName("idTextures")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdVariantes)
                    .HasColumnName("idVariantes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Prix).HasColumnName("prix");

                entity.HasOne(d => d.IdConditionnementsNavigation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.IdConditionnements)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("References_ibfk_4");

                entity.HasOne(d => d.IdCouleursNavigation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.IdCouleurs)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("References_ibfk_1");

                entity.HasOne(d => d.IdProduitsNavigation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.IdProduits)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("References_ibfk_5");

                entity.HasOne(d => d.IdTexturesNavigation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.IdTextures)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("References_ibfk_3");

                entity.HasOne(d => d.IdVariantesNavigation)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.IdVariantes)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("References_ibfk_2");
            });

            modelBuilder.Entity<Textures>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Transports>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contenance)
                    .HasColumnName("contenance")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Variantes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)");
            });
        }
    }
}