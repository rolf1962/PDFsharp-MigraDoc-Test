namespace PDFsharp_MigraDoc.WpfApp.Exporter
{
    public abstract class ExporterBase<T> where T : class
    {
        public ExporterBase(T dataSource = null)
        {
            DataSource = dataSource;
        }

        public T DataSource { get; set; }

        public abstract void DoExport();
    }
}
