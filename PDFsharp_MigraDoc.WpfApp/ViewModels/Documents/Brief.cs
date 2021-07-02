using GalaSoft.MvvmLight;

namespace PDFsharp_MigraDoc.WpfApp.ViewModels.Documents
{
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
