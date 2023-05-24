using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SklepProjekt.Models
{

    public class SklepContext : DbContext
    {
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Zamówienie> Zamówienia { get; set; }
        public DbSet<Szczegóły_zamówienia> Szczegóły_zamówienia { get; set; }
        public DbSet<Przesyłka> Przesyłki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zamówienie>()
                .HasRequired(z => z.Klient)
                .WithMany()
                .HasForeignKey(z => z.ID_klienta);

            modelBuilder.Entity<Szczegóły_zamówienia>()
                .HasRequired(sz => sz.Zamówienie)
                .WithMany(z => z.Szczegóły_zamówienia)
                .HasForeignKey(sz => sz.ID_zamówienia);

            modelBuilder.Entity<Szczegóły_zamówienia>()
                .HasRequired(sz => sz.Produkt)
                .WithMany()
                .HasForeignKey(sz => sz.ID_produktu);

            modelBuilder.Entity<Przesyłka>()
                .HasKey(p => p.ID_zamówienia);

            modelBuilder.Entity<Przesyłka>()
                .HasRequired(p => p.Zamówienie)
                .WithOptional()
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}