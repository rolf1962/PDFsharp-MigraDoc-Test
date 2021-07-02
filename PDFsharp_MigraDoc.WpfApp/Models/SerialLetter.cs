using System.Collections.ObjectModel;

namespace PDFsharp_MigraDoc.WpfApp.Models
{
    public class SerialLetter : ModelBase
    {
        private Person _sender;
        private string _text;

        public Person Sender
        {
            get => _sender; set
            {
                if (_sender != value)
                {
                    _sender = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Text
        {
            get => _text; set
            {
                if (Text != value)
                {
                    _text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Person> Recipients { get; set; } = new ObservableCollection<Person>();
    }
}
