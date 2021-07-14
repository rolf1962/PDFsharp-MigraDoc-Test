﻿using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc
{
    public class Brief : ExporterBase<ViewModels.Documents.Brief>
    {
        /// <summary>
        /// Erzeugt einen neuen <see cref="Brief">Exporter</see>
        /// </summary>
        /// <param name="datasource">Ein <see cref="ViewModels.Documents.Brief">ViewModel</see>
        /// mit den Daten für den Export.<br/>Der Parameter kann <see cref="null"/> 
        /// sein.<br/>Er ist i.d.R. immer null, wenn mehrere Dokumente erzeugt werden.<br/>
        /// Ein neues Dokument wird durch den Aufruf von <see cref="Exporter.ExporterBase{T}.DoExport"/> 
        /// erzeugt.<br/>Für jedes neue Dokument kann eine neue <see cref="Exporter.ExporterBase{T}.DataSource">
        /// Datenquelle</see> zugewiesen werden</param>
        public Brief(ViewModels.Documents.Brief datasource = null) : base(datasource)
        {
        }

        /// <summary>
        /// Erzeugt ein neues <see cref="Document"/> für ein Serienbrief Exemplar
        /// </summary>
        /// <returns></returns>
        public override Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();

            // ToDO: Wenn möglich, gesamtes Dokument mit Formularfeldern erzeugen

            return document;
        }

        /// <summary>
        /// Führt den Export der Daten aus dem <see cref="ViewModels.Documents.Brief">ViewModel</see> 
        /// in ein neu erzeugtes MigraDoc-Dokument aus.
        /// </summary>
        public override void DoExport()
        {
            if (null == DataSource) { throw new NullReferenceException($"{nameof(DataSource)} darf nicht NULL sein."); }

            string saveDirectory = Path.Combine(FileRoot, "MigraDoc");
            if (!Directory.Exists(saveDirectory)) { Directory.CreateDirectory(saveDirectory); }

            string filename = Path.Combine(saveDirectory, DataSource.GetType().Name + DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".pdf");

            // ------------------------------
            // Dokument vollständig neu erzeugen
            // ------------------------------

            // Create a MigraDoc document
            Document document = CreateDocument();

            // Add a section to the document
            Section section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = PageFormat.A4;
            float sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;

            {
                Paragraph paragraph = section.AddParagraph($"Viersen, {DateTime.Now.ToShortDateString()}");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
            }
            {
                Paragraph paragraph = section.AddParagraph($"{DataSource.AbsenderName} - {DataSource.AbsenderPostleitOrt} - {DataSource.AbsenderStrasseHausr}");
                paragraph.Format.Font.Size = 8;
                paragraph.Format.Font.Underline = Underline.Single;
                paragraph.Format.SpaceBefore = Unit.FromPoint(64);
            }
            section.AddParagraph(DataSource.EmpfaengerName);
            section.AddParagraph(DataSource.EmpfaengerStrasseHausnr);
            section.AddParagraph(DataSource.EmpfaengerPostleitzahlOrt);
            {
                Paragraph paragraph = section.AddParagraph(DataSource.Anrede);
                paragraph.Format.SpaceBefore = Unit.FromPoint(36);
                paragraph.Format.SpaceAfter = Unit.FromPoint(8);
            }
            section.AddParagraph(DataSource.Text);
            {
                Paragraph paragraph = section.AddParagraph(DataSource.Grussformel);
                paragraph.Format.SpaceBefore = Unit.FromPoint(24);
                paragraph.Format.SpaceAfter = Unit.FromPoint(36);
            }
            {
                float columnWidth = sectionWidth / 3;   // Spaltenbreite 1/3 der Abschnittsbreite
                Table table = section.AddTable();       // Die Tabelle benötigen wir die Linie unter der Unterschrift/über dem Namen
                table.AddColumn(columnWidth);
                table.AddRow();

                Cell cell = table[0, 0];
                cell.Format.Alignment = ParagraphAlignment.Center;
                cell.Borders.Top.Visible = true;
                cell.Borders.Left.Visible = false;
                cell.Borders.Right.Visible = false;
                cell.Borders.Bottom.Visible = false;

                Paragraph paragraph = cell.AddParagraph(DataSource.AbsenderName);
                paragraph.Format.SpaceBefore = Unit.FromPoint(8);
            }
            // ------------------------------ Ende Dokument vollständig neu erzeugen

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode: true);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}