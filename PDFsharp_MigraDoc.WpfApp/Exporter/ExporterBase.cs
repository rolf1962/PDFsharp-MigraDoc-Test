using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.WpfApp.Exporter
{
    public abstract class ExporterBase<T>
    {
        public ExporterBase(T dataSource)
        {
            DataSource = dataSource;
        }

        public T DataSource { get; set; }
    }
}
