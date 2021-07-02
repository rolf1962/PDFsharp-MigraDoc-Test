using Microsoft.Office.Interop.Word;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    public class Brief : ExporterBase<ViewModels.Documents.Brief>
    {
        public Brief(Application application, ViewModels.Documents.Brief brief) : base(application, brief)
        {
            Application = application;

            object templateFileName = GetTemplatePath(TemplateFileNames.Brief);
            Document = Application.Documents.Add(ref templateFileName);
        }

        public override void WriteToFormFields()
        {
            Document.FormFields[ref FormFieldNames.AbsName].Result = DataSource.AbsenderName;
            Document.FormFields[ref FormFieldNames.AbsPlzOrt].Result = DataSource.AbsenderPostleitOrt;
            Document.FormFields[ref FormFieldNames.AbsStrasseHausnr].Result = DataSource.AbsenderStrasseHausr;
            Document.FormFields[ref FormFieldNames.AbsUnterschrift].Result = DataSource.AbsenderUnterschrift;
            Document.FormFields[ref FormFieldNames.Anrede].Result = DataSource.Anrede;
            Document.FormFields[ref FormFieldNames.EmpfName].Result = DataSource.EmpfaengerName;
            Document.FormFields[ref FormFieldNames.EmpfPlzOrt].Result = DataSource.EmpfaengerPostleitzahlOrt;
            Document.FormFields[ref FormFieldNames.EmpfStrasseHausnr].Result = DataSource.EmpfaengerStrasseHausnr;
            Document.FormFields[ref FormFieldNames.Grussformel].Result = DataSource.Grussformel;
            Document.FormFields[ref FormFieldNames.Text].Result = DataSource.Text;
        }

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
