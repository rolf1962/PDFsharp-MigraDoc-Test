using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    public abstract class ExporterBase<T> : IDisposable
    {
        private bool disposedValue;

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen
                }

                // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                // TODO: Große Felder auf NULL setzen
                if (null != Document)
                {
                    if (Marshal.IsComObject(Document))
                    {
                        Marshal.FinalReleaseComObject(Document);
                    }
                    Document = null;
                }

                disposedValue = true;
            }
        }

        // // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
        // ~ExporterBase()
        // {
        //     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
