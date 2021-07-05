using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Xml
{
    public class ExporterBase<T> : Exporter.ExporterBase<T> where T : class
    {
        /// <summary>
        /// Erzeugt einen neuen Xml-Exporter
        /// </summary>
        /// <param name="dataSource">Die <see cref="Exporter.ExporterBase{T}.DataSource">Daten</see> für den Export.</param>
        public ExporterBase(T dataSource = null) : base(dataSource)
        {
        }

        /// <summary>
        /// Führt den Export der Daten aus dem <see cref="Exporter.ExporterBase{T}.DataSource"/>
        /// in eine neu erzeugte Xml-Datei aus.
        /// </summary>
        public override void DoExport()
        {
            if (null == DataSource) { throw new NullReferenceException($"{nameof(DataSource)} darf nicht NULL sein."); }

            string saveDirectory = Path.Combine(FileRoot, "Xml");
            if (!Directory.Exists(saveDirectory)) { Directory.CreateDirectory(saveDirectory); }

            string fullFilename = Path.Combine(saveDirectory, $"{GenericType.Name}{DateTime.Now:yyyyMMddhhmmss}.xml");

            XmlSerializer serializer = new XmlSerializer(GenericType);

            using (XmlTextWriter writer = new XmlTextWriter(fullFilename, Encoding.UTF8))
            {
                serializer.Serialize(writer, DataSource);
            }
            FileNames.Add(fullFilename);
        }
    }
}
