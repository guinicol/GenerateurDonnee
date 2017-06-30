using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GenerateurDonnee
{
    public partial class projetbiContext : DbContext
    {
        public virtual DbSet<Commandes> Commandes { get; set; }
        public virtual DbSet<Conditionnements> Conditionnements { get; set; }
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
            modelBuilder.Entity<Commandes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPays)
                    .HasColumnName("idPays")
                    .HasColumnType("int(11)");
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
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCommandes)
                    .HasColumnName("idCommandes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdReferences)
                    .HasColumnName("idReferences")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTransports)
                    .HasColumnName("idTransports")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(50)");
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