using MigraDoc.DocumentObjectModel;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Grussformel : BuildingBlockBase<ViewModels.Dokumente.Brief, Paragraph>
    {
        public Grussformel(ViewModels.Dokumente.Brief dataSource) : base(dataSource) { }

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
