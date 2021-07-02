using Microsoft.Office.Interop.Word;

namespace PDFsharp_MigraDoc.WpfApp.Exporter.Word
{
    public class Brief : ExporterBase<ViewModels.Documents.Brief>
    {
        public Brief(ViewModels.Documents.Brief datasource = null) : base(datasource)
        {
        }

        public override void WriteToFormFields()
        {
            object templateFileName = GetTemplatePath(TemplateFileNames.Brief);
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
