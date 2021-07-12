using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PDFsharp_MigraDoc.Exporter
{
    /// <summary>
    /// Abstrakte Basisklasse für alle Exporter
    /// </summary>
    /// <typeparam name="T">Die "Datenklasse" für den Export (i.d.R. aus 
    /// <see cref="ViewModels"/> oder <see cref="Models"/>)</typeparam>
    public abstract class ExporterBase<T> where T : class
    {
        /// <summary>
        /// Erzeugt ein neues <see cref="ExporterBase{T}"/>
        /// </summary>
        /// <param name="dataSource">Die Datenquelle vom Typ <typeparamref name="T"/> für den Export.</param>
        protected ExporterBase(T dataSource = null)
        {
            DataSource = dataSource;
        }

        /// <summary>
        /// Gibt die Datenquelle für den Export zurück oder legt sie fest. 
        /// Die Datenquelle ist immer vom Typ <typeparamref name="T"/>.
        /// </summary>
        public T DataSource { get; set; }

        /// <summary>
        /// Jede konkrete Ableitung von <see cref="ExporterBase{T}"/> muss diese Methode implementieren.
        /// Die Methode startet den Export der Daten in <see cref="DataSource"/>.
        /// </summary>
        public abstract void DoExport();

        /// <summary>
        /// Enthält den/die Namen der Exportdatei(en)
        /// </summary>
        public List<string> FileNames { get; } = new List<string>();

        /// <summary>
        /// Das Basisverzeichnis für die Speicherung der <see cref="FileNames">Exportdateien</see>.
        /// </summary>
        public static string FileRoot { get => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            Assembly.GetExecutingAssembly().GetName().Name); }
    }
}
