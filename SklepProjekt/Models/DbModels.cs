namespace SklepProjekt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // Klasa reprezentująca tabelę "Produkty"
    public class Produkt
    {
        [Key]
        public int ID_produktu { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Nazwa_produktu { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public decimal Cena { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int Dostępna_ilość { get; set; }
    }

    // Klasa reprezentująca tabelę "Klienci"
    public class Klient
    {
        [Key]
        public int ID_klienta { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Adres { get; set; }
        [EmailAddress(ErrorMessage = "Niepoprawny adres e-mail.")]
        public string Email { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer telefonu musi składać się z 9 cyfr.")]
        public string Numer_telefonu { get; set; }
    }

    // Klasa reprezentująca tabelę "Zamowienia"
    public class Zamowienie
    {
        [Key]

        public int ID_Zamowienia { get; set; }

        [ForeignKey("Klient")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int ID_klienta { get; set; }

        [ForeignKey("Produkt")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int ID_produktu { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public DateTime Data_Zamowienia { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Status_Zamowienia { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int Ilosc { get; set; }  
        public virtual Klient Klient { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}
