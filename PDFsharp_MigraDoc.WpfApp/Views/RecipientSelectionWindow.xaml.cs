using PDFsharp_MigraDoc.WpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PDFsharp_MigraDoc.WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für ReceiverSelectionWindow.xaml
    /// </summary>
    public partial class RecipientSelectionWindow : Window
    {
        public RecipientSelectionWindow(MainWindowViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
