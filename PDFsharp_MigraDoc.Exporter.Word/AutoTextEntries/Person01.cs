using Microsoft.Office.Interop.Word;
using System;

namespace PDFsharp_MigraDoc.Exporter.Word.AutoTextEntries
{
    public class Person01 : ExporterBase<Models.Person>
    {
        private string _ueberschrift;

        public Person01(Range targetRange, Template blockkatalog, Models.Person person) :
            base(targetRange: targetRange, blockkatalog: blockkatalog, dataSource: person)
        {
            Ueberschrift = "Person";
        }

        public string Ueberschrift { get => _ueberschrift; set => _ueberschrift = value; }

        public override void DoExport()
        {
            AutoTextEntry autoTextEntry = Blockkatalog.AutoTextEntries["Person01"];
            Range autoTextRange = autoTextEntry.Insert(Where: TargetRange, RichText: true);

            autoTextRange.FormFields["Ueberschrift"].Result = Ueberschrift;
            autoTextRange.FormFields["Nachname"].Result = DataSource.Name;
            autoTextRange.FormFields["Vorname"].Result = DataSource.FirstName;
            autoTextRange.FormFields["Geburtsdatum"].Result = DataSource.Birthdate?.ToShortDateString();
            autoTextRange.FormFields["Geburtsort"].Result = DataSource.Birthplace;
            autoTextRange.FormFields["Staatsangehoerigkeit"].Result = DataSource.Nationality;
            autoTextRange.FormFields["Strasse"].Result = DataSource.Street;
            autoTextRange.FormFields["Hausnr"].Result = DataSource.HouseNumber;
            autoTextRange.FormFields["Postleitzahl"].Result = DataSource.PostCode;
            autoTextRange.FormFields["Ort"].Result = DataSource.Place;
        }

        protected override void OpenFilesInViewer(string[] fileNames = null)
        {
            throw new NotImplementedException();
        }
    }
}
