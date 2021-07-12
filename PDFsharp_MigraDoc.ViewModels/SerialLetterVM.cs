using GalaSoft.MvvmLight;
using PDFsharp_MigraDoc.DataAccess;
using PDFsharp_MigraDoc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PDFsharp_MigraDoc.ViewModels
{
    /// <summary>
    /// Die Klasse stellt den einfachen Zugriff auf die Eigenschaften und Methoden von 
    /// <see cref="DataAccess.SerialLetterContext"/> und <see cref="Documents.Brief"/>-ViewModels 
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
        /// Erzeugt für alle <see cref="Models.SerialLetter.Recipients"/> <see cref="Documents.Brief"/>-ViewModels.
        /// </summary>
        /// <returns>Eine <see cref="IEnumerable{T}"/> von  <see cref="Documents.Brief"/>-ViewModels.</returns>
        public IEnumerable<Documents.Brief> GetBriefVMs()
        {
            return Recipients.Select(recipient => new Documents.Brief()
            {
                AbsenderName = $"{Sender.Vorname} {Sender.Name}",
                AbsenderPostleitOrt = $"{Sender.Postleitzahl} {Sender.Ort}",
                AbsenderStrasseHausr = $"{Sender.Strasse} {Sender.HausNr}",
                AbsenderUnterschrift = $"{Sender.Vorname} {Sender.Name}",
                
                Grussformel = recipient.Grussformel,
                Anrede = recipient.Anrede,
                EmpfaengerName = $"{recipient.Vorname} {recipient.Name}",
                EmpfaengerPostleitzahlOrt = $"{recipient.Postleitzahl} {recipient.Ort}",
                EmpfaengerStrasseHausnr = $"{recipient.Strasse} {recipient.HausNr}",

                Text = Text
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
        /// Gibt den <see cref="Models.SerialLetter.Sender"/> zurück.
        /// </summary>
        public Person Sender { get => SerialLetterContext.SerialLetter.Sender; }

        /// <summary>
        /// Gibt den <see cref="Models.SerialLetter.Text"/> zurück.
        /// </summary>
        public string Text { get => SerialLetterContext.SerialLetter.Text; }

        /// <summary>
        /// Gibt <see cref="Models.SerialLetter.Recipients"/> zurück.
        /// </summary>
        public ObservableCollection<Person> Recipients { get => SerialLetterContext.SerialLetter.Recipients; }

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
