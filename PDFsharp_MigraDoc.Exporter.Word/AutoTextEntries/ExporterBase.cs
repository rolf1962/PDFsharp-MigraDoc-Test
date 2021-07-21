using Microsoft.Office.Interop.Word;
using System;

namespace PDFsharp_MigraDoc.Exporter.Word.AutoTextEntries
{
    public abstract class ExporterBase<T> : Exporter.ExporterBase<T> where T : class
    {
        public ExporterBase(Range targetRange, Template blockkatalog, T dataSource) : base(dataSource: dataSource, openInViewer: false)
        {
            TargetRange = targetRange ?? throw new ArgumentNullException(nameof(targetRange));
            Blockkatalog = blockkatalog ?? throw new ArgumentNullException(nameof(blockkatalog));
        }

        protected Range TargetRange { get; private set; }
        protected Template Blockkatalog { get; private set; }
    }
}
