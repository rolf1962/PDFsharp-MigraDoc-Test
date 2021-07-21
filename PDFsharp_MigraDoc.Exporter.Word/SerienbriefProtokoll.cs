using Microsoft.Office.Interop.Word;
using PDFsharp_MigraDoc.ViewModels;
using System;

namespace PDFsharp_MigraDoc.Exporter.Word
{
    public class SerienbriefProtokoll : ExporterBase<SerialLetterVM>
    {
        public SerienbriefProtokoll(DateTime executionTime, SerialLetterVM datasource = null, bool openInViewer = true) : base(datasource, openInViewer)
        {
            SerienbriefErzeugt = executionTime;
        }

        public override void DoExport()
        {
            Document document = Application.Documents.Add();
            document.Content.SetRange(0, 0);
            document.ActiveWindow.ActivePane.Selection.EndKey(WdUnits.wdStory);

            Paragraph paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = "Protokoll zum Serienbrief";
            paragraph.Range.set_Style(WdBuiltinStyle.wdStyleHeading1);
            paragraph.Range.InsertParagraphAfter();


            paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = $"Ausführung: {SerienbriefErzeugt}";
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Paragraphs.Add();
            AutoTextEntries.Person01 senderAutoTextEntry = new AutoTextEntries.Person01(
                targetRange: paragraph.Range, 
                blockkatalog: Blockkatalog, 
                person: DataSource.SerialLetter.Sender);
            senderAutoTextEntry.Ueberschrift = "Absender";
            senderAutoTextEntry.DoExport();

            foreach (var recipient in DataSource.Recipients)
            {
                paragraph = document.Paragraphs.Add();
                AutoTextEntries.Person01 recipientAutoTextEntry = new AutoTextEntries.Person01(
                    targetRange: paragraph.Range, 
                    blockkatalog: Blockkatalog, 
                    person: recipient);
                recipientAutoTextEntry.Ueberschrift = "Empfänger";
                recipientAutoTextEntry.DoExport();
            }
        }

        public DateTime SerienbriefErzeugt { get; }
    }
}
