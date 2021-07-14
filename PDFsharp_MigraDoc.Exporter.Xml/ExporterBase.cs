using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PDFsharp_MigraDoc.Exporter.Xml
{
    /// <summary>
    /// Die Basisklasse für alle Xml-Exporter. 
    /// Für einfache Exporte der <see cref="Exporter.ExporterBase{T}.DataSource"/> reicht die Ausführung von <see cref="DoExport"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExporterBase<T> : Exporter.ExporterBase<T> where T : class
    {
        /// <summary>
        /// Erzeugt einen neuen Xml-Exporter
        /// </summary>
        /// <param name="dataSource">Die <see cref="Exporter.ExporterBase{T}.DataSource">Daten</see> für den Export.</param>
        public ExporterBase(T dataSource = null, bool openInViewer = true) : base(dataSource, openInViewer)
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

            string fullFilename = Path.Combine(saveDirectory, $"{DataSource.GetType().Name}{DateTime.Now:yyyyMMddhhmmss}.xml");

            XmlSerializer serializer = new XmlSerializer(DataSource.GetType());

            using (XmlTextWriter writer = new XmlTextWriter(fullFilename, Encoding.UTF8) { Formatting = Formatting.Indented })
            {
                serializer.Serialize(writer, DataSource);
            }

            FileNames.Add(fullFilename);

            if (OpenInViewer) { OpenFilesInViewer(new string[] { fullFilename }); }
        }

        protected override void OpenFilesInViewer(string[] fileNames = null)
        {
            if (null == fileNames || fileNames.Length == 0)
            {
                fileNames = FileNames.ToArray();
            }

            foreach (string filename in fileNames)
            {
                Process.Start(filename);
            }
        }
    }
}
