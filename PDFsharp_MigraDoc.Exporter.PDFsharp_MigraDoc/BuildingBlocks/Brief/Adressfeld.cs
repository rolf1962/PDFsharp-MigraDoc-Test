using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Adressfeld : BuildingBlockBase<ViewModels.Dokumente.Brief, Table>
    {
        public Adressfeld(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
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
                Table table = new Table();
                table.AddColumn(SectionWidth);
                table.AddRow();

                Cell cell = table[0, 0];

                // Complete sender above the recipient
                Paragraph paragraph = cell.AddParagraph($"{DataSource.AbsenderName} - {DataSource.AbsenderPostleitOrt} - {DataSource.AbsenderStrasseHausr}");
                paragraph.Format.Font.Size = 8;
                paragraph.Format.Font.Underline = Underline.Single;
                paragraph.Format.SpaceBefore = Unit.FromPoint(64);

                // Recipient
                cell.AddParagraph(DataSource.EmpfaengerName);
                cell.AddParagraph(DataSource.EmpfaengerStrasseHausnr);
                cell.AddParagraph($"{DataSource.EmpfaengerPostleitzahlOrt}");

                return table;
            }
        }
    }
}
