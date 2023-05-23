using System;
using System.Data.Entity.Migrations;

public partial class Initial : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Klients",
            c => new
                {
                    ID_klienta = c.Int(nullable: false, identity: true),
                    Imie = c.String(nullable: false),
                    Nazwisko = c.String(nullable: false),
                    Adres = c.String(nullable: false),
                    Email = c.String(),
                    Numer_telefonu = c.String(),
                })
            .PrimaryKey(t => t.ID_klienta);
        
        CreateTable(
            "dbo.Produkts",
            c => new
                {
                    ID_produktu = c.Int(nullable: false, identity: true),
                    Nazwa_produktu = c.String(nullable: false),
                    Opis = c.String(),
                    Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Dostępna_ilość = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ID_produktu);
        
        CreateTable(
            "dbo.Zamowienies",
            c => new
                {
                    ID_Zamowienia = c.Int(nullable: false, identity: true),
                    ID_klienta = c.Int(nullable: false),
                    ID_produktu = c.Int(nullable: false),
                    Data_Zamowienia = c.DateTime(nullable: false),
                    Status_Zamowienia = c.String(nullable: false),
                    Ilosc = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.ID_Zamowienia)
            .ForeignKey("dbo.Klients", t => t.ID_klienta, cascadeDelete: true)
            .ForeignKey("dbo.Produkts", t => t.ID_produktu, cascadeDelete: true)
            .Index(t => t.ID_klienta)
            .Index(t => t.ID_produktu);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.Zamowienies", "ID_produktu", "dbo.Produkts");
        DropForeignKey("dbo.Zamowienies", "ID_klienta", "dbo.Klients");
        DropIndex("dbo.Zamowienies", new[] { "ID_produktu" });
        DropIndex("dbo.Zamowienies", new[] { "ID_klienta" });
        DropTable("dbo.Zamowienies");
        DropTable("dbo.Produkts");
        DropTable("dbo.Klients");
    }
}
