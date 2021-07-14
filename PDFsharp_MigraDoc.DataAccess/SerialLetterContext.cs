using PDFsharp_MigraDoc.Models;
using System.Collections.Generic;

namespace PDFsharp_MigraDoc.DataAccess
{
    /// <summary>
    /// Die Klasse stellt die Daten für die Erzeugung von Serienbriefen bereit
    /// </summary>
    public class SerialLetterContext
    {
        /// <summary>
        /// Erzeugt einen neuen <see cref="SerialLetterContext"/>
        /// </summary>
        /// <param name="createSampleData">gibt an, ob Beispieldaten erzeugt werden sollen.</param>
        public SerialLetterContext(bool createSampleData = false)
        {
            if (createSampleData)
            {
                CreateSampleData();
            }
        }

        /// <summary>
        /// Erzeugt Beispieldaten
        /// </summary>
        private void CreateSampleData()
        {
            Person klaus = new Person()
            {
                Name = "Testmann",
                Vorname = "Klaus",
                Strasse = "Teststraße",
                HausNr = "123",
                Postleitzahl = "0815",
                Ort = "Testhausen",
            };
            Person gabriele = new Person()
            {
                Name = "Testmann",
                Vorname = "Gabriele",
                Strasse = "Teststraße",
                HausNr = "123",
                Postleitzahl = "0815",
                Ort = "Testhausen"
            };
            Person manfred = new Person()
            {
                Name = "Mustermann",
                Vorname = "Manfred",
                Strasse = "Musterstraße",
                HausNr = "123",
                Postleitzahl = "4711",
                Ort = "Musterdorf"
            };
            Person ilse = new Person()
            {
                Name = "Mustermann",
                Vorname = "Ilse",
                Strasse = "Musterstraße",
                HausNr = "123",
                Postleitzahl = "4711",
                Ort = "Musterdorf"
            };

            klaus.Anrede = $"{Anreden[0]}{klaus.Name}";
            klaus.Grussformel = Grussformeln[0];

            gabriele.Anrede = $"{Anreden[1]}{gabriele.Name}";
            gabriele.Grussformel = Grussformeln[1];

            manfred.Anrede = $"{Anreden[3]}{manfred.Vorname}";
            manfred.Grussformel = Grussformeln[1];

            ilse.Anrede = $"{Anreden[5]}{ilse.Name}";
            ilse.Grussformel = Grussformeln[2];

            Personen = new List<Person>() { klaus, gabriele, manfred, ilse };

            SerialLetter.Text = "Herzlichen Glückwunsch zum ersten Serienbrief. " +
                "Die Briefe können Sie als MS-Word oder PDF Dokumente erzeugen oder " +
                "einfach die Daten in eine XML-Datei speichern.";

            SerialLetter.Sender = manfred;
            SerialLetter.Recipients.Add(klaus);
            SerialLetter.Recipients.Add(gabriele);
            SerialLetter.Recipients.Add(ilse);
        }

        /// <summary>
        /// Gibt den Datencontainer für Serienbriefe zurück
        /// </summary>
        public SerialLetter SerialLetter { get; } = new SerialLetter();

        /// <summary>
        /// Gibt eine Liste aller vorhandenen <see cref="Person">Personen</see> zurück, die für 
        /// <see cref="SerialLetter.Recipients"/> und <see cref="SerialLetter.Sender"/> verwendet
        /// werden können.
        /// </summary>
        public IReadOnlyList<Person> Personen { get; private set; }

        /// <summary>
        /// Gibt eine Liste häufig verwendeter Briefanreden zurück
        /// </summary>
        public static IReadOnlyList<string> Anreden { get; } = new string[]
        {
            "Sehr geehrter Herr ",
            "Sehr geehrte Frau ",
            "Sehr geehrte Damen und Herrn ",
            "Hallo ",
            "Lieber Herr ",
            "Liebe Frau ",
        };

        /// <summary>
        /// Gibt eine Liste häufig verwendeter Grußformeln zurück
        /// </summary>
        public static IReadOnlyList<string> Grussformeln { get; } = new string[]
        {
            "Mit freundlichen Grüßen ",
            "Viele Grüße ",
            "Liebe Grüße "
        };
    }
}
