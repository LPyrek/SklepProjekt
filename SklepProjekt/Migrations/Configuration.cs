using SklepProjekt.Models;
using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<SklepContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(SklepContext context)
    {
        var produkt1 = new Produkt
        {
            Nazwa_produktu = "Rękawice treningowe",
            Opis = "Rękawice do treningu bokserskiego",
            Cena = 49.99m,
            Dostępna_ilość = 10,
        };

        var produkt2 = new Produkt
        {
            Nazwa_produktu = "Ochraniacze na piszczele",
            Opis = "Ochraniacze na piszczele do treningu MMA",
            Cena = 29.99m,
            Dostępna_ilość = 15,
        };

        var produkt3 = new Produkt
        {
            Nazwa_produktu = "Ochraniacz na zęby",
            Opis = "Ochraniacz na zęby",
            Cena = 29.99m,
            Dostępna_ilość = 25,
        };

        var klient1 = new Klient
        {
            ID_klienta = 1,
            Imie = "Janusz",
            Nazwisko = "Kowalski",
            Adres = "Poznań, ul. Poznańska 10/44",
            Email = "abc@email.com",
        };

        var klient2 = new Klient
        {
            ID_klienta = 2,
            Imie = "Adrian",
            Nazwisko = "Nowak",
            Adres = "Kraków, ul. Mazowiecka 124/43",
            Email = "costam@gmail.com",
        };


        context.Produkty.AddOrUpdate(p => p.Nazwa_produktu, produkt1, produkt2);
        context.Klienci.AddOrUpdate(p => p.ID_klienta, klient1);
        context.SaveChanges();
    }
}
