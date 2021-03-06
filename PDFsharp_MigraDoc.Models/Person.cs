using GalaSoft.MvvmLight;
using System;

namespace PDFsharp_MigraDoc.Models
{
    /// <summary>
    /// Die Klasse für Personen, die als Absender oder Empfänger 
    /// in Serienbriefen verwendet werden können
    /// </summary>
    public class Person : ViewModelBase
    {
        private string _name;
        private string _firstName;
        private DateTime? _birthdate;
        private string _birthplace;
        private string _nationality;
        private string _postCode;
        private string _place;
        private string _street;
        private string _houseNumber;
        private string _salutation;
        private string _greeting;

        /// <summary>
        /// Gibt den Nachnamen zurück oder legt ihn fest
        /// </summary>
        public string Name { get => _name; set => Set(ref _name, value); }

        /// <summary>
        /// Gibt den/die Vornamen zurück oder legt ihn/sie fest
        /// </summary>
        public string FirstName { get => _firstName; set => Set(ref _firstName, value); }

        /// <summary>
        /// Gibt das Geburtsdatum zurück oder legt es fest
        /// </summary>
        public DateTime? Birthdate { get => _birthdate; set => Set(ref _birthdate, value); }

        /// <summary>
        /// Gibt den Geburtsort zurück oder legt ign fest
        /// </summary>
        public string Birthplace { get => _birthplace; set => Set(ref _birthplace, value); }

        /// <summary>
        /// Gibt die Staatsangehörigkeit zurück oder legt sie fest
        /// </summary>
        public string Nationality { get => _nationality; set => Set(ref _nationality, value); }

        /// <summary>
        /// Gibt die Postleitzahl zurück oder legt sie fest
        /// </summary>
        public string PostCode { get => _postCode; set => Set(ref _postCode, value); }

        /// <summary>
        /// Gibt den Ort zurück oder legt ihn fest
        /// </summary>
        public string Place { get => _place; set => Set(ref _place, value); }

        /// <summary>
        /// Gibt die Straße zurück oder legt sie fest
        /// </summary>
        public string Street { get => _street; set => Set(ref _street, value); }

        /// <summary>
        /// Gibt die Hausnummer zurück oder legt sie fest
        /// </summary>
        public string HouseNumber { get => _houseNumber; set => Set(ref _houseNumber, value); }


        /// <summary>
        /// Gibt die Anrede zurück oder legt fest fest
        /// </summary>
        public string Salutation { get => _salutation; set => Set(ref _salutation, value); }

        /// <summary>
        /// Gibt die Grußformel zurück oder legt sie fest
        /// </summary>
        public string Greeting { get => _greeting; set => Set(ref _greeting, value); }
    }
}
