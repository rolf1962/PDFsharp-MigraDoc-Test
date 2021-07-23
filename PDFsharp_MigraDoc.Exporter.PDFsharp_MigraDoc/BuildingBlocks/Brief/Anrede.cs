using MigraDoc.DocumentObjectModel;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Anrede : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        public Anrede(ViewModels.Dokumente.Brief dataSource) : base(dataSource) { }

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
