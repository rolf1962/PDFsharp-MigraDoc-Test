using Microsoft.Office.Interop.Word;
using System.IO;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    public abstract class ExporterBase<T>
    {
        public ExporterBase(Application application, T dataSource)
        {
            Application = application;
            DataSource = dataSource;
        }

        protected Application Application { get; set; }

        protected Document Document { get; set; }

        public T DataSource { get; }

        public static string GetTemplatePath(string TemplateName)
        {
            return Path.GetFullPath(Path.Combine("WordTemplates", TemplateName));
        }

        public abstract void WriteToFormFields();
    }
}
