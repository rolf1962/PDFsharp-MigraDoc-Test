using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc
{
    public abstract class ExporterBase<T> : Exporter.ExporterBase<T> where T : class
    {
        public ExporterBase(T dataSource = null, bool openInViewer = true) : base(dataSource, openInViewer)
        {

        }

        public abstract Document CreateDocument();

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
