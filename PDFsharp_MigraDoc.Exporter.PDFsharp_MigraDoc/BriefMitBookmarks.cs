using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc
{
    public class BriefMitBookmarks : ExporterBase<ViewModels.Dokumente.Brief>
    {
        public BriefMitBookmarks(ViewModels.Dokumente.Brief datasource = null, bool openInViewer = true) : base(datasource, openInViewer)
        {
        }

        public override Document CreateDocument()
        {
            throw new NotImplementedException();
        }

        public override void DoExport()
        {
            throw new NotImplementedException();
        }

        protected override void OpenFilesInViewer(string[] fileNames = null)
        {
            throw new NotImplementedException();
        }
    }
}
