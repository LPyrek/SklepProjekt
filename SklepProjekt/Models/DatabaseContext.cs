using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SklepProjekt.Models
{
    public class SklepContext : DbContext
    {
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zamowienie>()
                .HasRequired(z => z.Klient)
                .WithMany()
                .HasForeignKey(z => z.ID_klienta);

            modelBuilder.Entity<Zamowienie>()
                .HasRequired(z => z.Produkt)
                .WithMany()
                .HasForeignKey(z => z.ID_produktu);

            base.OnModelCreating(modelBuilder);
        }
    }
}