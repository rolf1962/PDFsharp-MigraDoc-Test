using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    public abstract class ExporterBase<T> : Exporter.ExporterBase<T>, IDisposable
    {
        private bool disposedValue;
        private bool _visible;

        public ExporterBase(T dataSource) : base(dataSource)
        {
            Application = new Application();
            Visible = false;
        }

        protected Application Application { get; set; }

        public static string GetTemplatePath(string TemplateName)
        {
            return Path.GetFullPath(Path.Combine("WordTemplates", TemplateName));
        }

        public bool Visible
        {
            get => _visible;
            set
            {
                Application.Visible = _visible = value;
            }
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
                if (null != Application)
                {
                    if (Marshal.IsComObject(Application))
                    {
                        foreach(Document document in Application.Documents)
                        {
                            Marshal.FinalReleaseComObject(document);
                        }

                        Application.Visible = true;

                        Marshal.FinalReleaseComObject(Application);
                    }
                    Application = null;
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
