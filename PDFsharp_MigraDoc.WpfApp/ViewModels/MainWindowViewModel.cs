using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PDFsharp_MigraDoc.WpfApp.DataAccess;
using PDFsharp_MigraDoc.WpfApp.Models;
using PDFsharp_MigraDoc.WpfApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PDFsharp_MigraDoc.WpfApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Person _selectedRecipient;

        public MainWindowViewModel()
        {
            SerialLetterContext = new SerialLetterContext(true);

            CloseWindowCommand = new RelayCommand<Window>(w => CloseWindowExec(w));
            OpenRecipientSelectionCommand = new RelayCommand(OpenRecipientSelectionExecute);
            AddRecipientCommand = new RelayCommand<Person>(p => AddRecipientExecute(p), p => AddRecipientCanExecute(p));
            RemoveRecipientCommand = new RelayCommand(RemoveRecipientExecute, RemoveRecipientCanExeute);
            CreateSerialLettersCommand = new RelayCommand(CreateSerialLettersExecute, CreateSerialLettersCanExecute);

            SelectedRecipient = SerialLetter.Recipients.Count > 0 ? SerialLetter.Recipients[0] : null;
        }

        private bool CreateSerialLettersCanExecute()
        {
            return SerialLetter.Recipients.Count > 0;
        }

        private void CreateSerialLettersExecute()
        {
            var briefViewModels = SerialLetter.Recipients.Select(recipient => new Documents.Brief() 
            {
                AbsenderName = $"{SerialLetter.Sender.Vorname} {SerialLetter.Sender.Name}",
                AbsenderPostleitOrt = $"{SerialLetter.Sender.Postleitzahl} {SerialLetter.Sender.Ort}",
                AbsenderStrasseHausr = $"{SerialLetter.Sender.Strasse} {SerialLetter.Sender.HausNr}",
                AbsenderUnterschrift = $"{SerialLetter.Sender.Vorname} {SerialLetter.Sender.Name}",
                Grussformel = recipient.Grussformel,

                Anrede = recipient.Anrede,
                EmpfaengerName = $"{recipient.Vorname} {recipient.Name}",
                EmpfaengerPostleitzahlOrt = $"{recipient.Postleitzahl} {recipient.Ort}",
                EmpfaengerStrasseHausnr = $"{recipient.Strasse} {recipient.HausNr}",

                Text = SerialLetter.Text
            });

            using (Exporter.Word.Brief briefExporter = new Exporter.Word.Brief())
            {
                foreach (Documents.Brief briefViewModel in briefViewModels)
                {
                    briefExporter.DataSource = briefViewModel;
                    briefExporter.WriteToFormFields();
                }
            }

            //Parallel.ForEach(SerialLetter.Recipients, recipient =>
            //{
            //    Documents.Brief briefViewModel = new Documents.Brief()
            //    {
            //        AbsenderName = $"{SerialLetter.Sender.Vorname} {SerialLetter.Sender.Name}",
            //        AbsenderPostleitOrt = $"{SerialLetter.Sender.Postleitzahl} {SerialLetter.Sender.Ort}",
            //        AbsenderStrasseHausr = $"{SerialLetter.Sender.Strasse} {SerialLetter.Sender.HausNr}",
            //        AbsenderUnterschrift = $"{SerialLetter.Sender.Vorname} {SerialLetter.Sender.Name}",
            //        Grussformel = recipient.Grussformel,

            //        Anrede = recipient.Anrede,
            //        EmpfaengerName = $"{recipient.Vorname} {recipient.Name}",
            //        EmpfaengerPostleitzahlOrt = $"{recipient.Postleitzahl} {recipient.Ort}",
            //        EmpfaengerStrasseHausnr = $"{recipient.Strasse} {recipient.HausNr}",

            //        Text = SerialLetter.Text
            //    };

            //    using (Exporter.Word.Brief briefExporter = new Exporter.Word.Brief(briefViewModel))
            //    {
            //        briefExporter.WriteToFormFields();
            //    }
            //});
        }

        private bool AddRecipientCanExecute(Person p)
        {
            return p != null && !SerialLetter.Recipients.Contains(p);
        }

        private void AddRecipientExecute(Person p)
        {
            SerialLetter.Recipients.Add(p);
            SelectedRecipient = p;
        }

        private void CloseWindowExec(Window window)
        {
            window.Close();
        }

        private bool RemoveRecipientCanExeute()
        {
            return null != SelectedRecipient;
        }

        private void RemoveRecipientExecute()
        {
            int currentIndex = SerialLetter.Recipients.IndexOf(SelectedRecipient);
            SerialLetter.Recipients.Remove(SelectedRecipient);
            if (currentIndex < SerialLetter.Recipients.Count)
            {
                SelectedRecipient = SerialLetter.Recipients[currentIndex];
            }
            else if (SerialLetter.Recipients.Count > 0)
            {
                SelectedRecipient = SerialLetter.Recipients[SerialLetter.Recipients.Count - 1];
            }
        }

        private void OpenRecipientSelectionExecute()
        {
            RecipientSelectionWindow receiverSelectionWindow = new RecipientSelectionWindow(this);
            receiverSelectionWindow.ShowDialog();
        }

        private SerialLetterContext SerialLetterContext { get; }

        public Person SelectedRecipient
        {
            get => _selectedRecipient; set
            {
                if (_selectedRecipient != value)
                {
                    _selectedRecipient = value;
                    RaisePropertyChanged();
                }
            }
        }

        public SerialLetter SerialLetter { get => SerialLetterContext.SerialLetter; }

        public IReadOnlyList<Person> People { get => SerialLetterContext.Personen; }
        public IReadOnlyList<string> Anreden { get => SerialLetterContext.Anreden; }
        public IReadOnlyList<string> Grussformeln { get => SerialLetterContext.Grussformeln; }

        public RelayCommand<Window> CloseWindowCommand { get; }
        public RelayCommand OpenRecipientSelectionCommand { get; }
        public RelayCommand<Person> AddRecipientCommand { get; }
        public RelayCommand RemoveRecipientCommand { get; }
        public RelayCommand CreateSerialLettersCommand { get; }
    }
}
