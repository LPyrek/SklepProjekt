using System;
using System.Data.Entity.Migrations;

public partial class First : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Klients",
            c => new
                {
                    ID_klienta = c.Int(nullable: false, identity: true),
                    Imię = c.String(),
                    Nazwisko = c.String(),
                    Adres = c.String(),
                    EMail = c.String(),
                    Numer_telefonu = c.String(),
                })
            .PrimaryKey(t => t.ID_klienta);
        
        CreateTable(
            "dbo.Produkts",
            c => new
                {
                    ID_produktu = c.Int(nullable: false, identity: true),
                    Nazwa_produktu = c.String(),
                    Opis = c.String(),
                    Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Dostępna_ilość = c.Int(nullable: false),
                    Kategoria_produktu = c.String(),
                })
            .PrimaryKey(t => t.ID_produktu);
        
        CreateTable(
            "dbo.Przesyłka",
            c => new
                {
                    ID_zamówienia = c.Int(nullable: false),
                    Sposób_dostawy = c.String(),
                    Adres_dostawy = c.String(),
                    Data_wysyłki = c.DateTime(nullable: false),
                })
            .PrimaryKey(t => t.ID_zamówienia)
            .ForeignKey("dbo.Zamówienie", t => t.ID_zamówienia, cascadeDelete: true)
            .Index(t => t.ID_zamówienia);
        
        CreateTable(
            "dbo.Zamówienie",
            c => new
                {
                    ID_zamówienia = c.Int(nullable: false, identity: true),
                    ID_klienta = c.Int(nullable: false),
                    Data_zamówienia = c.DateTime(nullable: false),
                    Status_zamówienia = c.String(),
                })
            .PrimaryKey(t => t.ID_zamówienia)
            .ForeignKey("dbo.Klients", t => t.ID_klienta, cascadeDelete: true)
            .Index(t => t.ID_klienta);
        
        CreateTable(
            "dbo.Szczegóły_zamówienia",
            c => new
                {
                    ID_szczegóły = c.Int(nullable: false, identity: true),
                    ID_zamówienia = c.Int(nullable: false),
                    ID_produktu = c.Int(nullable: false),
                    Ilość = c.Int(nullable: false),
                    Cena_jednostkowa = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
            .PrimaryKey(t => t.ID_szczegóły)
            .ForeignKey("dbo.Produkts", t => t.ID_produktu, cascadeDelete: true)
            .ForeignKey("dbo.Zamówienie", t => t.ID_zamówienia, cascadeDelete: true)
            .Index(t => t.ID_zamówienia)
            .Index(t => t.ID_produktu);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.Przesyłka", "ID_zamówienia", "dbo.Zamówienie");
        DropForeignKey("dbo.Szczegóły_zamówienia", "ID_zamówienia", "dbo.Zamówienie");
        DropForeignKey("dbo.Szczegóły_zamówienia", "ID_produktu", "dbo.Produkts");
        DropForeignKey("dbo.Zamówienie", "ID_klienta", "dbo.Klients");
        DropIndex("dbo.Szczegóły_zamówienia", new[] { "ID_produktu" });
        DropIndex("dbo.Szczegóły_zamówienia", new[] { "ID_zamówienia" });
        DropIndex("dbo.Zamówienie", new[] { "ID_klienta" });
        DropIndex("dbo.Przesyłka", new[] { "ID_zamówienia" });
        DropTable("dbo.Szczegóły_zamówienia");
        DropTable("dbo.Zamówienie");
        DropTable("dbo.Przesyłka");
        DropTable("dbo.Produkts");
        DropTable("dbo.Klients");
    }
}
