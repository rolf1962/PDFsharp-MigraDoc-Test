using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Anrede : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        public Anrede(ViewModels.Dokumente.Brief dataSource) : base(dataSource)
        {

        }

        public override string Beschreibung => "Baustein für einen Standardbrief. Besteht aus der Anrede (e.g. \"Sehr geehrte(r)...\"";

        protected override string Name => "Anrede";

        public override Paragraph DocumentObject
        {
            get
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Format.SpaceBefore = Unit.FromPoint(36);
                paragraph.Format.SpaceAfter = Unit.FromPoint(8);
                paragraph.AddText(DataSource.Anrede);

                return paragraph;
            }
        }
    }
}
