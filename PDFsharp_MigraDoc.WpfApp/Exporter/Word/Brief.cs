using Microsoft.Office.Interop.Word;
using System;
using System.IO;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    /// <summary>
    /// Die Klasse ist eine Ableitung von <see cref="Word.ExporterBase{T}"/>. 
    /// Sie stellt einen Exporter für <see cref="ViewModels.Documents.Brief"/> bereit
    /// </summary>
    public class Brief : ExporterBase<ViewModels.Documents.Brief>
    {
        /// <summary>
        /// Erzeugt einen neuen <see cref="Exporter.Word.Brief">Exporter</see>
        /// </summary>
        /// <param name="datasource">Ein <see cref="ViewModels.Documents.Brief">ViewModel</see>
        /// mit den Daten für den Export.<br/>Der Parameter kann <see cref="null"/> 
        /// sein.<br/>Er ist i.d.R. immer null, wenn mehrere Dokumente erzeugt werden.<br/>
        /// Ein neues Dokument wird durch den Aufruf von <see cref="Exporter.ExporterBase{T}.DoExport"/> 
        /// erzeugt.<br/>Für jedes neue Dokument kann eine neue <see cref="Exporter.ExporterBase{T}.DataSource">
        /// Datenquelle</see> zugewiesen werden</param>
        public Brief(ViewModels.Documents.Brief datasource = null) : base(datasource)
        {
        }

        /// <summary>
        /// Führt den Export der Daten aus dem <see cref="ViewModels.Documents.Brief">ViewModel</see> 
        /// in ein neu erzeugtes Word-Dokument aus.
        /// </summary>
        public override void DoExport()
        {
            if (null == DataSource) { throw new NullReferenceException($"{nameof(DataSource)} darf nicht NULL sein."); }

            string saveDirectory = Path.Combine(FileRoot, "Word");
            if (!Directory.Exists(saveDirectory)) { Directory.CreateDirectory(saveDirectory); }

            object templateFileName = GetTemplatePath(TemplateFileNames.Brief);
            object fullFilename = Path.Combine(saveDirectory, GenericType.Name + DateTime.Now.ToString("yyyyMMddhhmmssffff"));

            Document document = Application.Documents.Add(ref templateFileName);

            document.FormFields[ref FormFieldNames.AbsName].Result = DataSource.AbsenderName;
            document.FormFields[ref FormFieldNames.AbsPlzOrt].Result = DataSource.AbsenderPostleitOrt;
            document.FormFields[ref FormFieldNames.AbsStrasseHausnr].Result = DataSource.AbsenderStrasseHausr;
            document.FormFields[ref FormFieldNames.AbsUnterschrift].Result = DataSource.AbsenderUnterschrift;
            document.FormFields[ref FormFieldNames.Anrede].Result = DataSource.Anrede;
            document.FormFields[ref FormFieldNames.EmpfName].Result = DataSource.EmpfaengerName;
            document.FormFields[ref FormFieldNames.EmpfPlzOrt].Result = DataSource.EmpfaengerPostleitzahlOrt;
            document.FormFields[ref FormFieldNames.EmpfStrasseHausnr].Result = DataSource.EmpfaengerStrasseHausnr;
            document.FormFields[ref FormFieldNames.Grussformel].Result = DataSource.Grussformel;
            document.FormFields[ref FormFieldNames.Text].Result = DataSource.Text;

            document.SaveAs2(FileName: ref fullFilename);
            FileNames.Add(Convert.ToString(fullFilename));
        }

        /// <summary>
        /// Die Namen den Textmarken/Formularfelder 
        /// </summary>
        private static class FormFieldNames
        {
            public static object AbsName = "AbsName";
            public static object AbsPlzOrt = "AbsPlzOrt";
            public static object AbsStrasseHausnr = "AbsStrasseHausnr";
            public static object AbsUnterschrift = "AbsUnterschrift";
            public static object Anrede = "Anrede";
            public static object EmpfName = "EmpfName";
            public static object EmpfPlzOrt = "EmpfPlzOrt";
            public static object EmpfStrasseHausnr = "EmpfStrasseHausnr";
            public static object Grussformel = "Grussformel";
            public static object Text = "Text";
        }
    }
}
