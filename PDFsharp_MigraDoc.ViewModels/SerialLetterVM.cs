using PDFsharp_MigraDoc.DataAccess;
using PDFsharp_MigraDoc.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PDFsharp_MigraDoc.ViewModels
{
    /// <summary>
    /// Die Klasse stellt den einfachen Zugriff auf die Eigenschaften und Methoden von 
    /// <see cref="DataAccess.SerialLetterContext"/> und <see cref="Dokumente.Brief"/>-ViewModels 
    /// für alle <see cref="SerialLetter.Recipients"/> bereit.
    /// </summary>
    public class SerialLetterVM : ViewModelBase
    {
        /// <summary>
        /// Erzeugt ein neues <see cref="SerialLetterVM">SerialLetter-ViewModel</see>
        /// </summary>
        public SerialLetterVM()
        {
            SerialLetterContext = new SerialLetterContext(true);
        }

        /// <summary>
        /// Erzeugt für alle <see cref="Models.SerialLetter.Recipients"/> <see cref="Dokumente.Brief"/>-ViewModels.
        /// </summary>
        /// <returns>Eine <see cref="IEnumerable{T}"/> von  <see cref="Dokumente.Brief"/>-ViewModels.</returns>
        public IEnumerable<Dokumente.Brief> GetBriefVMs()
        {
            return Recipients.Select(recipient => new Dokumente.Brief()
            {
                AbsenderName = $"{SerialLetter.Sender.FirstName} {SerialLetter.Sender.Name}",
                AbsenderPostleitOrt = $"{SerialLetter.Sender.PostCode} {SerialLetter.Sender.Place}",
                AbsenderStrasseHausr = $"{SerialLetter.Sender.Street} {SerialLetter.Sender.HouseNumber}",
                AbsenderUnterschrift = $"{SerialLetter.Sender.FirstName} {SerialLetter.Sender.Name}",
                
                Grussformel = recipient.Greeting,
                Anrede = recipient.Salutation,
                EmpfaengerName = $"{recipient.FirstName} {recipient.Name}",
                EmpfaengerPostleitzahlOrt = $"{recipient.PostCode} {recipient.Place}",
                EmpfaengerStrasseHausnr = $"{recipient.Street} {recipient.HouseNumber}",

                Text = SerialLetter.Text
            });
        }

        /// <summary>
        /// Gibt den <see cref="DataAccess.SerialLetterContext">Datencontainer</see> zurück
        /// </summary>
        private SerialLetterContext SerialLetterContext { get; }

        /// <summary>
        /// Gibt den in <see cref="DataAccess.SerialLetterContext"/> verwalteten <see cref="Models.SerialLetter"/> zurück.
        /// </summary>
        public SerialLetter SerialLetter { get => SerialLetterContext.SerialLetter; }

        /// <summary>
        /// Gibt <see cref="Models.SerialLetter.Recipients"/> zurück.
        /// </summary>
        public ObservableCollection<Person> Recipients { get => SerialLetterContext.SerialLetter.Recipients; }

        /// <summary>
        /// Gibt alle <see cref="Person">Personen</see> aus der 
        /// <see cref="SerialLetterContext">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<Person> People { get => SerialLetterContext.People; }

        /// <summary>
        /// Gibt alle Anreden aus der <see cref="SerialLetterContext.Salutations">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Salutations { get => SerialLetterContext.Salutations; }

        /// <summary>
        /// Gibt alle Grußformeln aus der <see cref="SerialLetterContext.Greetings">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Greetings { get => SerialLetterContext.Greetings; }
    }
}
