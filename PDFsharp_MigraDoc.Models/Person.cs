﻿using GalaSoft.MvvmLight;

namespace PDFsharp_MigraDoc.Models
{
    /// <summary>
    /// Die Klasse für Personen, die als Absender oder Empfänger 
    /// in Serienbriefen verwendet werden können
    /// </summary>
    public class Person : ViewModelBase
    {
        private string _name;
        private string _vorname;
        private string _postleitzahl;
        private string _ort;
        private string _strasse;
        private string _hausNr;
        private string _anrede;
        private string _grussformel;

        /// <summary>
        /// Gibt den Nachnamen zurück oder legt ihn fest
        /// </summary>
        public string Name { get => _name; set => Set(ref _name, value); }

        /// <summary>
        /// Gibt den/die Vornamen zurück oder legt ihn/sie fest
        /// </summary>
        public string Vorname { get => _vorname; set => Set(ref _vorname, value); }

        /// <summary>
        /// Gibt die Postleitzahl zurück oder legt sie fest
        /// </summary>
        public string Postleitzahl { get => _postleitzahl; set => Set(ref _postleitzahl, value); }

        /// <summary>
        /// Gibt den Ort zurück oder legt ihn fest
        /// </summary>
        public string Ort { get => _ort; set => Set(ref _ort, value); }

        /// <summary>
        /// Gibt die Straße zurück oder legt sie fest
        /// </summary>
        public string Strasse { get => _strasse; set => Set(ref _strasse, value); }

        /// <summary>
        /// Gibt die Hausnummer zurück oder legt sie fest
        /// </summary>
        public string HausNr { get => _hausNr; set => Set(ref _hausNr, value); }


        /// <summary>
        /// Gibt die Anrede zurück oder legt fest fest
        /// </summary>
        public string Anrede { get => _anrede; set => Set(ref _anrede, value); }

        /// <summary>
        /// Gibt die Grußformel zurück oder legt sie fest
        /// </summary>
        public string Grussformel { get => _grussformel; set => Set(ref _grussformel, value); }
    }
}
