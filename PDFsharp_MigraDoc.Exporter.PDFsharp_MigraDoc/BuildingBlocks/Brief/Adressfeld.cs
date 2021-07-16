using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks
{
    public class Adressfeld : BuildingBlockBase<ViewModels.Dokumente.Brief, Table>
    {
        private Unit sectionWidth;

        public Adressfeld(ViewModels.Dokumente.Brief dataSource, Unit sectionWidth) : base(dataSource)
        {
            this.sectionWidth = sectionWidth;
        }

        public override string Beschreibung => throw new NotImplementedException();

        protected override string Name => throw new NotImplementedException();

        public override Table DocumentObject
        {
            get
            {
                Table table = new Table();
                table.AddColumn(sectionWidth);
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
