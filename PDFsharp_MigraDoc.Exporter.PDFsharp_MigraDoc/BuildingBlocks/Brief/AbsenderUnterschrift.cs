using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class AbsenderUnterschrift : BuildingBlockBase<ViewModels.Dokumente.Brief, Table>
    {
        private Unit sectionWidth;
        public AbsenderUnterschrift(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
        {
            this.sectionWidth = sectionWidth;
        }

        public override string Beschreibung => "Baustein für einen Standardbrief. Besteht aus dem Absendernamen und einer Linie darüber.";
        protected override string Name => "Unterschrift/Absendername";

        public override Table DocumentObject
        {
            get
            {
                float columnWidth = sectionWidth / 3;   // Spaltenbreite 1/3 der Abschnittsbreite
                Table table = new Table();
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

                return table;
            }
        }
    }
}
