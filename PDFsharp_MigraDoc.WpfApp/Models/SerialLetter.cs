using System.Collections.ObjectModel;

namespace PDFsharp_MigraDoc.WpfApp.Models
{
    /// <summary>
    /// Die Klasse stellt die Daten für Serienbriefe bereit
    /// </summary>
    public class SerialLetter : ModelBase
    {
        private Person _sender;
        private string _text;

        /// <summary>
        /// Eine <see cref="Person"/>, die als Absender verwendet wird.
        /// </summary>
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

        /// <summary>
        /// Der im Serienbrief auszugebende Text
        /// </summary>
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

        /// <summary>
        /// Alle <see cref="Person">Empfänger</see> des Serienbriefs
        /// </summary>
        public ObservableCollection<Person> Recipients { get; set; } = new ObservableCollection<Person>();
    }
}
