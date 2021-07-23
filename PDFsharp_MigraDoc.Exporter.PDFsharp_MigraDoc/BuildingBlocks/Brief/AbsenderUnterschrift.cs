using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class AbsenderUnterschrift : BuildingBlockBase<ViewModels.Dokumente.Brief, Table>
    {
        public AbsenderUnterschrift(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
        {
            if (sectionWidth == Unit.Empty || sectionWidth == Unit.Zero)
            {
                throw new ArgumentException(
                    $"Der Wert von {nameof(sectionWidth)} darf nicht {Unit.Empty} oder {Unit.Zero} sein.", 
                    nameof(sectionWidth));
            }

            SectionWidth = sectionWidth;
        }

        public override Table DocumentObject
        {
            get
            {
                float columnWidth = SectionWidth / 3;   // Spaltenbreite 1/3 der Abschnittsbreite
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
