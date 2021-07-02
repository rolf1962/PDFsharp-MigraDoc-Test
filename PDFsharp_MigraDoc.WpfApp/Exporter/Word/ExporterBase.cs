using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    /// <summary>
    /// Die abstrakte Basisklasse für alle Word-Exporter.
    /// </summary>
    /// <typeparam name="T">Die (ViewModel-) Typ mit den zu exportierenden Daten</typeparam>
    public abstract class ExporterBase<T> : Exporter.ExporterBase<T>, IDisposable where T : class
    {
        private bool disposedValue;
        private bool _visible;

        /// <summary>
        /// Erzeugt einen neuen Word-Exporter
        /// </summary>
        /// <param name="dataSource">Die <see cref="Exporter.ExporterBase{T}.DataSource">Daten</see> für den Export.</param>
        public ExporterBase(T dataSource = null) : base(dataSource)
        {
            Application = new Application();
            Visible = false;
        }

        /// <summary>
        /// Die Instanz von <see cref="Application">MS-Word</see> mit der gearbeitet wird.
        /// </summary>
        protected Application Application { get; set; }

        /// <summary>
        /// Gibt den vollständigen Dateipfad einer Vorlage zurück
        /// </summary>
        /// <param name="TemplateName"></param>
        /// <returns></returns>
        public static string GetTemplatePath(string TemplateName)
        {
            return Path.GetFullPath(Path.Combine("WordTemplates", TemplateName));
        }

        /// <summary>
        /// Zeigt das Anwendungsfenster von <see cref="Application">MS-Word an, 
        /// blendet es aus oder gibt die aktuelle Sichtbarkeit zurück</see>
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set
            {
                Application.Visible = _visible = value;
            }
        }

        #region Implementierung von IDisposable
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
                        foreach (Document document in Application.Documents)
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
        #endregion Implementierung von IDisposable
    }
}
