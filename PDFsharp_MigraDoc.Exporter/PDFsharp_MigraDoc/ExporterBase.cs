using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.Exporter.PDFsharp_MigraDoc
{
    public abstract class ExporterBase<T> : Exporter.ExporterBase<T> where T : class
    {
        public ExporterBase(T dataSource = null) : base(dataSource)
        {

        }

        public abstract Document CreateDocument();
    }
}
