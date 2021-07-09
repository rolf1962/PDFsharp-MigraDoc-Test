using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PDFsharp_MigraDoc.Exporter
{
    public abstract class ExporterBase<T> where T : class
    {
        public ExporterBase(T dataSource = null)
        {
            DataSource = dataSource;
            GenericType = typeof(T);
        }

        public T DataSource { get; set; }
        public Type GenericType { get; }

        public abstract void DoExport();

        public List<string> FileNames { get; } = new List<string>();

        public static string FileRoot { get => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            Assembly.GetExecutingAssembly().GetName().Name); }
    }
}
