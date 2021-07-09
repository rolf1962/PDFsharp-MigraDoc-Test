using GalaSoft.MvvmLight;
using PDFsharp_MigraDoc.DataAccess;
using PDFsharp_MigraDoc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PDFsharp_MigraDoc.ViewModels
{
    public class SerialLetterVM : ViewModelBase
    {
        public SerialLetterVM()
        {
            SerialLetterContext = new SerialLetterContext(true);
        }

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
        /// Der Datencontainer
        /// </summary>
        private SerialLetterContext SerialLetterContext { get; }

        public SerialLetter SerialLetter { get => SerialLetterContext.SerialLetter; }

        public Person Sender { get => SerialLetterContext.SerialLetter.Sender; }

        public string Text { get => SerialLetterContext.SerialLetter.Text; }

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
