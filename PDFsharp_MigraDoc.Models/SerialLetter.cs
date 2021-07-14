using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace PDFsharp_MigraDoc.Models
{
    /// <summary>
    /// Die Klasse stellt die Daten für Serienbriefe bereit
    /// </summary>
    public class SerialLetter : ViewModelBase
    {
        private Person _sender;
        private string _text;

        /// <summary>
        /// Eine <see cref="Person"/>, die als Absender verwendet wird.
        /// </summary>
        public Person Sender { get => _sender; set => Set(ref _sender, value); }

        /// <summary>
        /// Der im Serienbrief auszugebende Text
        /// </summary>
        public string Text { get => _text; set => Set(ref _text, value); }

        /// <summary>
        /// Alle <see cref="Person">Empfänger</see> des Serienbriefs
        /// </summary>
        public ObservableCollection<Person> Recipients { get; } = new ObservableCollection<Person>();
    }
}
