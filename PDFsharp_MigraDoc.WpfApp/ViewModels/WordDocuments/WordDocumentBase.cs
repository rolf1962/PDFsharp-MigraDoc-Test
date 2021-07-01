using GalaSoft.MvvmLight;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFsharp_MigraDoc.WpfApp.ViewModels.WordDocuments
{
    public abstract class WordDocumentBase : ViewModelBase
    {
        protected Application Application { get; set; }
        protected Document Document { get; set; }

        protected Dictionary<string, object> FieldData { get; } = new Dictionary<string, object>();

        public abstract void WriteToFormFields();

        public static string GetTemplatePath(string TemplateName)
        {
            return Path.GetFullPath(Path.Combine("WordTemplates", TemplateName));
        }
    }
}
