namespace PDFsharp_MigraDoc.WpfApp.Models
{
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
