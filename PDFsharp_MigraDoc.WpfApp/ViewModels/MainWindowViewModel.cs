using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PDFsharp_MigraDoc.WpfApp.DataAccess;
using PDFsharp_MigraDoc.WpfApp.Models;
using PDFsharp_MigraDoc.WpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PDFsharp_MigraDoc.WpfApp.ViewModels
{
    /// <summary>
    /// Das ViewModel für <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private Person _selectedRecipient;

        /// <summary>
        /// Erzeugt ein neues <see cref="MainWindowViewModel"/>
        /// </summary>
        public MainWindowViewModel()
        {
            SerialLetterContext = new SerialLetterContext(true);

            CloseWindowCommand = new RelayCommand<Window>(w => CloseWindowExec(w));
            OpenRecipientSelectionCommand = new RelayCommand(OpenRecipientSelectionExecute);
            AddRecipientCommand = new RelayCommand<Person>(p => AddRecipientExecute(p), p => AddRecipientCanExecute(p));
            RemoveRecipientCommand = new RelayCommand(RemoveRecipientExecute, RemoveRecipientCanExeute);
            CreateSerialLettersCommand = new RelayCommand(CreateSerialLettersExecute, CreateSerialLettersCanExecute);
            CreateXmlCommand = new RelayCommand(CreateXmlExecute, CreateXmlCanExecute);
            SelectedRecipient = SerialLetter.Recipients.Count > 0 ? SerialLetter.Recipients[0] : null;
        }

        /// <summary>
        /// Der Datencontainer
        /// </summary>
        private SerialLetterContext SerialLetterContext { get; }

        /// <summary>
        /// Der aktuell ausgewählte Empfänger
        /// </summary>
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

        /// <summary>
        /// Gibt die <see cref="SerialLetter">Serienbriefdaten</see> zurück
        /// </summary>
        public SerialLetter SerialLetter { get => SerialLetterContext.SerialLetter; }

        /// <summary>
        /// Gibt alle <see cref="Person">Personen</see> aus der 
        /// <see cref="SerialLetterContext">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<Person> People { get => SerialLetterContext.Personen; }

        /// <summary>
        /// Gibt alle Anreden aus der <see cref="SerialLetterContext.Anreden">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Anreden { get => SerialLetterContext.Anreden; }

        /// <summary>
        /// Gibt alle Grußformeln aus der <see cref="SerialLetterContext.Grussformeln">Datenquelle</see> zurück.
        /// </summary>
        public IReadOnlyList<string> Grussformeln { get => SerialLetterContext.Grussformeln; }

        #region Commands
        #region CreateSerialLettersCommand
        
        /// <summary>
        /// Command zum Start der Serienbrieferzeugung
        /// </summary>
        public RelayCommand CreateSerialLettersCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="CreateSerialLettersCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool CreateSerialLettersCanExecute()
        {
            return SerialLetter.Recipients.Count > 0;
        }

        /// <summary>
        /// Führt <see cref="CreateSerialLettersCommand"/> aus
        /// </summary>
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
                    briefExporter.DoExport();
                }
            }
        }
        #endregion CreateSerialLettersCommand

        #region CreateXmlCommand
        public RelayCommand CreateXmlCommand { get; }
        private bool CreateXmlCanExecute()
        {
            return SerialLetter.Recipients.Count > 0;
        }

        private void CreateXmlExecute()
        {
            Exporter.Xml.ExporterBase<SerialLetter> exporter = new Exporter.Xml.ExporterBase<SerialLetter>(SerialLetter);
            exporter.DoExport();
        }


        #endregion CreateXmlCommand

        #region AddRecipientCommand

        /// <summary>
        /// Command zum Anfügen eines Empfängers ans die <see cref="SerialLetter.Recipients">Liste</see>
        /// </summary>
        public RelayCommand<Person> AddRecipientCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="AddRecipientCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <param name="p">die <see cref="Person"/>, die angefügt werden soll</param>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool AddRecipientCanExecute(Person p)
        {
            return p != null && !SerialLetter.Recipients.Contains(p);
        }

        /// <summary>
        /// Führt <see cref="AddRecipientCommand"/> aus
        /// </summary>
        /// <param name="p">die <see cref="Person"/>, die angefügt werden soll</param>
        private void AddRecipientExecute(Person p)
        {
            SerialLetter.Recipients.Add(p);
            SelectedRecipient = p;
        }
        #endregion AddRecipientCommand

        #region CloseWindowCommand

        /// <summary>
        /// Command zum Schließen von Fenstern
        /// </summary>
        public RelayCommand<Window> CloseWindowCommand { get; }

        /// <summary>
        /// Führt <see cref="CloseWindowCommand"/> aus
        /// </summary>
        /// <param name="window">Das zu schließende Fenster</param>
        private void CloseWindowExec(Window window)
        {
            window.Close();
        }
        #endregion CloseWindowCommand

        #region RemoveRecipientCommand

        /// <summary>
        /// Command zum Entfernen eines Empfängers aus der <see cref="SerialLetter.Recipients">Liste</see>
        /// </summary>
        public RelayCommand RemoveRecipientCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="RemoveRecipientCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool RemoveRecipientCanExeute()
        {
            return null != SelectedRecipient;
        }

        /// <summary>
        /// Führt <see cref="RemoveRecipientCommand"/> aus
        /// </summary>
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
        #endregion RemoveRecipientCommand

        #region OpenRecipientSelectionCommand

        /// <summary>
        /// Command zum Öffnen des Fensters zur Bearbeitung der <see cref="SerialLetter.Recipients">Empfängerliste</see>
        /// </summary>
        public RelayCommand OpenRecipientSelectionCommand { get; }
        /// <summary>
        /// Führt <see cref="OpenRecipientSelectionCommand"/> aus
        /// </summary>
        private void OpenRecipientSelectionExecute()
        {
            RecipientSelectionWindow receiverSelectionWindow = new RecipientSelectionWindow(this);
            receiverSelectionWindow.ShowDialog();
        }
        #endregion OpenRecipientSelectionCommand
        #endregion Commands
    }
}
