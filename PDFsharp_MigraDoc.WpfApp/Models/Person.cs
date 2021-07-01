namespace PDFsharp_MigraDoc.WpfApp.Models
{
    public class Person : ModelBase
    {
        private string name;
        private string vorname;
        private string postleitzahl;
        private string ort;
        private string strasse;
        private string hausNr;
        private string anrede;
        private string grussformel;

        public string Name
        {
            get => name; internal set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Vorname
        {
            get => vorname; internal set
            {
                if (vorname != value)
                {
                    vorname = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Postleitzahl
        {
            get => postleitzahl; internal set
            {
                if (postleitzahl != value)
                {
                    if (postleitzahl != value)
                    {
                        postleitzahl = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
        public string Ort
        {
            get => ort; internal set
            {
                if (ort != value)
                {
                    if (ort != value)
                    {
                        ort = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
        public string Strasse
        {
            get => strasse; internal set
            {
                if (strasse != value)
                {
                    strasse = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string HausNr
        {
            get => hausNr; internal set
            {
                if (hausNr != value)
                {
                    hausNr = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Anrede
        {
            get => anrede; set
            {
                if (anrede != value)
                {
                    anrede = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Grussformel
        {
            get => grussformel; set
            {
                if (grussformel != value)
                {
                    grussformel = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
