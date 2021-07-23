using MigraDoc.DocumentObjectModel;
using System;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Briefkopf : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        public Briefkopf(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
        {
            if (sectionWidth == Unit.Empty || sectionWidth == Unit.Zero)
            {
                throw new ArgumentException(
                    $"Der Wert von {nameof(sectionWidth)} darf nicht {Unit.Empty} oder {Unit.Zero} sein.",
                    nameof(sectionWidth));
            }

            SectionWidth = sectionWidth;
        }

        public override Paragraph DocumentObject
        {
            get
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Format.AddTabStop(SectionWidth, TabAlignment.Right);
                paragraph.AddText(DataSource.AbsenderName);
                paragraph.AddTab();
                paragraph.AddText($"{DataSource.AbsenderPostleitOrt}, {DateTime.Now.ToShortDateString()}");

                return paragraph;
            }
        }
    }
}
