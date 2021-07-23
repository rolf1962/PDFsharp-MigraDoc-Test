using MigraDoc.DocumentObjectModel.Tables;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc.BuildingBlocks.Forms
{
    public class Person01 : BuildingBlockBase<Models.Person, Table>
    {
        private string _ueberschrift;

        public Person01(Models.Person person) : base(person) { }

        public string Ueberschrift { get => _ueberschrift; set => _ueberschrift = value; }

        public override Table DocumentObject
        {
            get
            {
                Table table = new Table();

                for (int ii = 0; ii < 4; ii++) { table.AddColumn(); }
                for (int ii = 0; ii < 7; ii++) { table.AddRow(); }

                table[1, 0].AddParagraph("Name");
                table[1, 1].AddParagraph("Vorname");
                table[3, 0].AddParagraph("Geburtsdatum");
                table[3, 1].AddParagraph("Geburtsort");
                table[3, 2].AddParagraph("Staatsangehörigkeit");
                table[5, 0].AddParagraph("Straße");
                table[5, 1].AddParagraph("Hausnr");
                table[5, 2].AddParagraph("Postleitzahl");
                table[5, 3].AddParagraph("Ort");

                table[0, 0].AddParagraph(Ueberschrift);
                table[2, 0].AddParagraph(DataSource.Name);
                table[2, 1].AddParagraph(DataSource.FirstName);
                table[4, 0].AddParagraph(DataSource.Birthdate?.ToShortDateString());
                table[4, 1].AddParagraph(DataSource.Birthplace);
                table[4, 2].AddParagraph(DataSource.Nationality);
                table[6, 0].AddParagraph(DataSource.Street);
                table[6, 1].AddParagraph(DataSource.HouseNumber);
                table[6, 2].AddParagraph(DataSource.PostCode);
                table[6, 3].AddParagraph(DataSource.Place);

                return table;
            }
        }
    }
}
