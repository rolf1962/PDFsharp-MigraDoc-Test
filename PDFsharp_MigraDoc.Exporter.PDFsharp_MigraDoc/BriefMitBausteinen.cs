using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks;
using PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks.Dokumente;
using System;
using System.IO;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc
{
    public class BriefMitBausteinen : ExporterBase<ViewModels.Dokumente.Brief>
    {
        public BriefMitBausteinen(ViewModels.Dokumente.Brief datasource = null, bool openInViewer = true) : base(datasource, openInViewer)
        {
        }

        public override Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();
            return document;
        }

        public override void DoExport()
        {
            string saveDirectory = Path.Combine(FileRoot, "MigraDoc");
            if (!Directory.Exists(saveDirectory)) { Directory.CreateDirectory(saveDirectory); }

            string filename = Path.Combine(saveDirectory, DataSource.GetType().Name + DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".pdf");

            // Create a MigraDoc document
            Document document = CreateDocument();

            // Add a section to the document
            // ------------------------------
            Section section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = PageFormat.A4;
            Unit sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;
            // ------------------------------

            // Build the document with Blocks
            // ------------------------------
            // Footer
            Paragraph paragraph = new FusszeilePaginierungRechts().DocumentObject;
            section.Footers.Primary.Add(paragraph);
            section.Footers.EvenPage.Add(paragraph.Clone());

            // Letterhead
            section.Add(new Briefkopf(DataSource, sectionWidth).DocumentObject);
            // Sender and Recipient
            section.Add(new Adressfeld(DataSource, sectionWidth).DocumentObject);
            // Salutation
            section.Add(new Anrede(DataSource).DocumentObject);
            // Text
            section.AddParagraph(DataSource.Text);
            // Greeting
            section.Add(new Grussformel(DataSource).DocumentObject);
            // Signaturefield 
            section.Add(new AbsenderUnterschrift(DataSource, sectionWidth).DocumentObject);
            // ------------------------------ Build the document with Blocks

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode: true);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            pdfRenderer.PdfDocument.Save(filename);

            FileNames.Add(filename);

            if (OpenInViewer) { OpenFilesInViewer(new string[] { filename }); }
        }
    }
}
