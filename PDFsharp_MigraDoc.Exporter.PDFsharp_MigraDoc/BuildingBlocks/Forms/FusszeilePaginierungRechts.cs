using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks.Forms
{
    public class FusszeilePaginierungRechts : BuildingBlockBase<Paragraph>
    {
        public FusszeilePaginierungRechts() 
        {
        }

        protected override string Name => "Paginierung rechts";

        public override string Beschreibung => "Baustein für einen Standardbrief. Besteht aus rechts ausgerichteter Paginierung \"Seite n / n \".";

        public override Paragraph DocumentObject 
        {
            get
            {
                // Add the footer with page numbering
                Paragraph paragraph = new Paragraph();
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Borders.Top.Visible = true;
                paragraph.Format.Borders.DistanceFromTop = 8;
                paragraph.Format.Borders.Left.Visible = false;
                paragraph.Format.Borders.Right.Visible = false;
                paragraph.Format.Borders.Bottom.Visible = false;
                paragraph.AddTab();
                paragraph.AddText("Seite ");
                paragraph.AddPageField();
                paragraph.AddText(" von ");
                paragraph.AddNumPagesField();

                return paragraph;
            }
        }
    }
}
