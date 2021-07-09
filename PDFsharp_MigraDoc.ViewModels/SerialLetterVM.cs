using GalaSoft.MvvmLight;
using PDFsharp_MigraDoc.DataAccess;
using PDFsharp_MigraDoc.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PDFsharp_MigraDoc.ViewModels
{
    public class SerialLetterVM : ViewModelBase
    {
        public SerialLetterVM()
        {
            SerialLetterContext = new SerialLetterContext(true);
        }

        /// <summary>
        /// Der Datencontainer
        /// </summary>
        private SerialLetterContext SerialLetterContext { get; }

        public SerialLetter SerialLetter { get => SerialLetterContext.SerialLetter; }

        public Person Sender { get => SerialLetterContext.SerialLetter.Sender; }

        public string Text { get => SerialLetterContext.SerialLetter.Text; }

        public ObservableCollection<Person> Recipients { get => SerialLetterContext.SerialLetter.Recipients;
        }
        /// <summary>
        /// Gibt alle <see cref="Person">Personen</see> aus der 
        /// <see cref="SerialLetterContext">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<Person> People { get => SerialLetterContext.Personen; }

        /// <summary>
        /// Gibt alle Anreden aus der <see cref="SerialLetterContext.Anreden">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Anreden { get => SerialLetterContext.Anreden; }

        /// <summary>
        /// Gibt alle Grußformeln aus der <see cref="SerialLetterContext.Grussformeln">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Grussformeln { get => SerialLetterContext.Grussformeln; }
    }
}
