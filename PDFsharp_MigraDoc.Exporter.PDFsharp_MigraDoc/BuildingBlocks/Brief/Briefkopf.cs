using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Briefkopf : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        private Unit sectionWidth;

        public Briefkopf(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
        {
            this.sectionWidth = sectionWidth;
        }

        public override string Beschreibung => throw new NotImplementedException();

        protected override string Name => throw new NotImplementedException();

        public override Paragraph DocumentObject
        {
            get
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Format.AddTabStop(sectionWidth, TabAlignment.Right);
                paragraph.AddText(DataSource.AbsenderName);
                paragraph.AddTab();
                paragraph.AddText($"{DataSource.AbsenderPostleitOrt}, {DateTime.Now.ToShortDateString()}");

                return paragraph;
            }
        }
    }
}
