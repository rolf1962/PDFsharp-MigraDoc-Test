using PDFsharp_MigraDoc.Models;
using System;
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
                FirstName = "Klaus",
                Birthdate = new DateTime(1973, 2, 23),
                Birthplace = "Testdorf",
                Nationality = "deutsch",
                Street = "Teststraße",
                HouseNumber = "123",
                PostCode = "0815",
                Place = "Testhausen",
            };
            Person gabriele = new Person()
            {
                Name = "Testmann",
                FirstName = "Gabriele",
                Birthdate = new DateTime(1975, 5, 5),
                Birthplace = "Testhausen",
                Nationality = "deutsch",
                Street = "Teststraße",
                HouseNumber = "123",
                PostCode = "0815",
                Place = "Testhausen"
            };
            Person manfred = new Person()
            {
                Name = "Mustermann",
                FirstName = "Manfred",
                Birthdate = new DateTime(1985, 8, 12),
                Birthplace = "Musterstadt",
                Nationality = "deutsch",
                Street = "Musterstraße",
                HouseNumber = "123",
                PostCode = "4711",
                Place = "Musterdorf"
            };
            Person ilse = new Person()
            {
                Name = "Mustermann",
                FirstName = "Ilse",
                Birthdate = new DateTime(1984, 12, 24),
                Birthplace = "Esbjerg",
                Nationality = "dänisch",
                Street = "Musterstraße",
                HouseNumber = "123",
                PostCode = "4711",
                Place = "Musterdorf"
            };

            klaus.Salutation = $"{Salutations[0]}{klaus.Name}";
            klaus.Greeting = Greetings[0];

            gabriele.Salutation = $"{Salutations[1]}{gabriele.Name}";
            gabriele.Greeting = Greetings[1];

            manfred.Salutation = $"{Salutations[3]}{manfred.FirstName}";
            manfred.Greeting = Greetings[1];

            ilse.Salutation = $"{Salutations[5]}{ilse.Name}";
            ilse.Greeting = Greetings[2];

            People = new List<Person>() { klaus, gabriele, manfred, ilse };

            SerialLetter.Text = "Herzlichen Glückwunsch zum ersten Serienbrief. " +
                "Die Briefe können Sie als MS-Word oder PDF Dokumente erzeugen oder " +
                "einfach die Daten in eine XML-Datei speichern.";

            SerialLetter.Sender = manfred;
            SerialLetter.Recipients.Add(gabriele);
            //SerialLetter.Recipients.Add(klaus);
            //SerialLetter.Recipients.Add(ilse);
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
        public IReadOnlyList<Person> People { get; private set; }

        /// <summary>
        /// Gibt eine Liste häufig verwendeter Briefanreden zurück
        /// </summary>
        public static IReadOnlyList<string> Salutations { get; } = new string[]
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
        public static IReadOnlyList<string> Greetings { get; } = new string[]
        {
            "Mit freundlichen Grüßen ",
            "Viele Grüße ",
            "Liebe Grüße "
        };
    }
}
