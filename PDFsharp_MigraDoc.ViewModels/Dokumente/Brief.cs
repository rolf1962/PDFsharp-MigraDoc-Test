namespace PDFsharp_MigraDoc.ViewModels.Dokumente
{
    /// <summary>
    /// Die Klasse mit der Datenstruktur, wie sie vom <see cref="Exporter.Word.Brief">Exportziel</see>
    /// erwartet wird.
    /// </summary>
    public class Brief : ViewModelBase
    {
        private string _absenderName;
        private string _absenderPostleitOrt;
        private string _absenderStrasseHausr;
        private string _empfaengerName;
        private string _empfaengerPostleitzahlOrt;
        private string _empfaengerStrasseHausnr;
        private string _anrede;
        private string _text;
        private string _grussformel;
        private string _absenderUnterschrift;

        /// <summary>
        /// Gibt den vollständigen Namen des Absenders zurück oder legt ihn fest
        /// </summary>
        public string AbsenderName
        {
            get => _absenderName;
            set
            {
                if (_absenderName != value)
                {
                    if (_absenderName != value)
                    {
                        _absenderName = value;
                        RaisePropertyChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gibt Postleitzahl und Ort des Absenders zurück oder legt sie fest
        /// </summary>
        public string AbsenderPostleitOrt
        {
            get => _absenderPostleitOrt;
            set
            {
                if (_absenderPostleitOrt != value)
                {
                    if (_absenderPostleitOrt != value)
                    {
                        _absenderPostleitOrt = value;
                        RaisePropertyChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gibt Straße und Hausnummer des Absenders zurück oder legt sie fest
        /// </summary>
        public string AbsenderStrasseHausr
        {
            get => _absenderStrasseHausr;
            set
            {
                if (_absenderStrasseHausr != value)
                {
                    _absenderStrasseHausr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt den vollständigen Namen des Empfängers zurück oder legt ihn fest
        /// </summary>
        public string EmpfaengerName
        {
            get => _empfaengerName;
            set
            {
                if (_empfaengerName != value)
                {
                    _empfaengerName = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt Postleitzahl und Ort des Empfängers zurück oder legt ihn fest
        /// </summary>
        public string EmpfaengerPostleitzahlOrt
        {
            get => _empfaengerPostleitzahlOrt;
            set
            {
                if (_empfaengerPostleitzahlOrt != value)
                {
                    _empfaengerPostleitzahlOrt = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt Straße und Hausnummer des Empfängers zurück oder legt ihn fest
        /// </summary>
        public string EmpfaengerStrasseHausnr
        {
            get => _empfaengerStrasseHausnr;
            set
            {
                if (_empfaengerStrasseHausnr != value)
                {
                    _empfaengerStrasseHausnr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt die Anrede des Empfängers zurück oder legt sie fest
        /// </summary>
        public string Anrede
        {
            get => _anrede;
            set
            {
                if (_anrede != value)
                {
                    _anrede = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt den Brieftext zurück oder legt ihn fest
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    RaisePropertyChanged();
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
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gibt die Unterschrift (Name und Vorname) des Absenders zurück oder legt sie fest
        /// </summary>
        public string AbsenderUnterschrift
        {
            get => _absenderUnterschrift;
            set
            {
                if (_absenderUnterschrift != value)
                {
                    _absenderUnterschrift = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
