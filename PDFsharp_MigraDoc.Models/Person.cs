namespace PDFsharp_MigraDoc.Models
{
    /// <summary>
    /// Die Klasse für Personen, die als Absender oder Empfänger 
    /// in Serienbriefen verwendet werden können
    /// </summary>
    public class Person : ModelBase
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
        public string Name
        {
            get => _name; 
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt den/die Vornamen zurück oder legt ihn/sie fest
        /// </summary>
        public string Vorname
        {
            get => _vorname; 
            set
            {
                if (_vorname != value)
                {
                    _vorname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt die Postleitzahl zurück oder legt sie fest
        /// </summary>
        public string Postleitzahl
        {
            get => _postleitzahl; 
            set
            {
                if (_postleitzahl != value)
                {
                    if (_postleitzahl != value)
                    {
                        _postleitzahl = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gibt den Ort zurück oder legt ihn fest
        /// </summary>
        public string Ort
        {
            get => _ort; 
            set
            {
                if (_ort != value)
                {
                    if (_ort != value)
                    {
                        _ort = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gibt die Straße zurück oder legt sie fest
        /// </summary>
        public string Strasse
        {
            get => _strasse; 
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt die Hausnummer zurück oder legt sie fest
        /// </summary>
        public string HausNr
        {
            get => _hausNr; 
            set
            {
                if (_hausNr != value)
                {
                    _hausNr = value;
                    NotifyPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Gibt die Anrede zurück oder legt fest fest
        /// </summary>
        public string Anrede
        {
            get => _anrede; 
            set
            {
                if (_anrede != value)
                {
                    _anrede = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt die Grußformel zurück oder legt sie fest
        /// </summary>
        public string Grussformel
        {
            get => _grussformel; 
            set
            {
                if (_grussformel != value)
                {
                    _grussformel = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
