using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Grussformel : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        public Grussformel(ViewModels.Dokumente.Brief dataSource) : base(dataSource)
        {

        }

        public override string Beschreibung => "Baustein für einen Standardbrief. Besteht aus der Grußformel (e.g. \"Mit freundlichen Grüßen\"";

        protected override string Name => "Grußformel";

        public override Paragraph DocumentObject
        {
            get
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Format.SpaceBefore = Unit.FromPoint(24);
                paragraph.Format.SpaceAfter = Unit.FromPoint(36);
                paragraph.AddText(DataSource.Grussformel);

                return paragraph;
            }
        }
    }
}
