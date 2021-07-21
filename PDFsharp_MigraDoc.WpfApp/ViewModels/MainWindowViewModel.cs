using GalaSoft.MvvmLight.CommandWpf;
using PDFsharp_MigraDoc.Models;
using PDFsharp_MigraDoc.ViewModels;
using PDFsharp_MigraDoc.WpfApp.Views;
using System;
using System.ComponentModel;
using System.Windows;

namespace PDFsharp_MigraDoc.WpfApp.ViewModels
{
    /// <summary>
    /// Das ViewModel für <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private Person _selectedRecipient;
        private bool _openFiles = true;

        /// <summary>
        /// Erzeugt ein neues <see cref="MainWindowViewModel"/>
        /// </summary>
        public MainWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand<Window>(w => CloseWindowExec(w));
            OpenRecipientSelectionCommand = new RelayCommand(OpenRecipientSelectionExecute);
            AddRecipientCommand = new RelayCommand<Person>(p => AddRecipientExecute(p), p => AddRecipientCanExecute(p));
            RemoveRecipientCommand = new RelayCommand(RemoveRecipientExecute, RemoveRecipientCanExeute);
            CreateWordDocumentsCommand = new RelayCommand(CreateWordDocumentsExecute, CreateWordDocumentsCanExecute);
            CreateMigraDocDocumentsCommand = new RelayCommand(CreateMigraDocDocumentsExecute, CreateMigraDocDocumentsCanExecute);
            CreateMigraDocDocumentsWithBuildingBlocksCommand = new RelayCommand(CreateMigraDocDocumentsWithBuildingBlocksExecute, CreateMigraDocDocumentsWithBuildingBlocksCanExecute);
            CreateXmlCommand = new RelayCommand(CreateXmlExecute, CreateXmlCanExecute);
            SelectedRecipient = SerialLetterVM.Recipients.Count > 0 ? SerialLetterVM.Recipients[0] : null;
        }

        /// <summary>
        /// Gibt den aktuell ausgewählten Empfänger zurück oder legt ihn fest
        /// </summary>
        public Person SelectedRecipient { get => _selectedRecipient; set => Set(ref _selectedRecipient, value); }

        /// <summary>
        /// Gibt zurück oder legt fest, ob erzeugte Dateien angezeigt werden sollen 
        /// </summary>
        public bool OpenFilesInViewer { get => _openFiles; set => Set(ref _openFiles, value); }

        public SerialLetterVM SerialLetterVM { get; } = new SerialLetterVM();

        #region Commands
        #region CreateWordDocumentsCommand

        /// <summary>
        /// Command zum Start der Serienbrieferzeugung mit MS-Word
        /// </summary>
        public RelayCommand CreateWordDocumentsCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="CreateWordDocumentsCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool CreateWordDocumentsCanExecute()
        {
            return SerialLetterVM.Recipients.Count > 0;
        }

        /// <summary>
        /// Führt <see cref="CreateWordDocumentsCommand"/> aus
        /// </summary>
        private void CreateWordDocumentsExecute()
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, doWorkEventArgs) =>
                {
                    IsBusy = true;

                    using (Exporter.Word.Brief briefExporter = new Exporter.Word.Brief(openInViewer: OpenFilesInViewer))
                    {
                        foreach (PDFsharp_MigraDoc.ViewModels.Dokumente.Brief briefViewModel in SerialLetterVM.GetBriefVMs())
                        {

                            briefExporter.DataSource = briefViewModel;
                            briefExporter.DoExport();
                        }

                        using (Exporter.Word.SerienbriefProtokoll protokoll = new Exporter.Word.SerienbriefProtokoll(
                            executionTime:briefExporter.ExecutionTime, 
                            datasource: SerialLetterVM, 
                            openInViewer: OpenFilesInViewer))
                        {
                            protokoll.DoExport();
                        }
                    }
                };
                worker.RunWorkerCompleted += (sender, doWorkEventArgs) =>
                {
                    IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                App.Logger.Error(ex, $"Fehler bei {nameof(CreateWordDocumentsExecute)}\n{ex.Message}");
                IsBusy = false;
            }

        }
        #endregion CreateWordDocumentsCommand

        #region CreateMigraDocDocumentsCommand

        /// <summary>
        /// Command zum Start der Serienbrieferzeugung mit PDFsharp-MigraDoc
        /// </summary>
        public RelayCommand CreateMigraDocDocumentsCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="CreateMigraDocDocumentsCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool CreateMigraDocDocumentsCanExecute()
        {
            return SerialLetterVM.Recipients.Count > 0;
        }

        /// <summary>
        /// Führt <see cref="CreateMigraDocDocumentsCommand"/> aus
        /// </summary>
        private void CreateMigraDocDocumentsExecute()
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, doWorkEventArgs) =>
                {
                    IsBusy = true;

                    Exporter.PDFsharp_MigraDoc.Brief briefExporter = new Exporter.PDFsharp_MigraDoc.Brief(openInViewer: OpenFilesInViewer);
                    foreach (PDFsharp_MigraDoc.ViewModels.Dokumente.Brief briefViewModel in SerialLetterVM.GetBriefVMs())
                    {
                        briefExporter.DataSource = briefViewModel;
                        briefExporter.DoExport();
                    }
                };
                worker.RunWorkerCompleted += (sender, doWorkEventArgs) =>
                {
                    IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                App.Logger.Error(ex, $"Fehler bei {nameof(CreateMigraDocDocumentsExecute)}\n{ex.Message}");
                IsBusy = false;
            }

        }
        #endregion CreateMigraDocDocumentsCommand

        #region CreateMigraDocDocumentsWithBuildingBlocksCommand

        /// <summary>
        /// Command zum Start der Serienbrieferzeugung mit PDFsharp-MigraDoc
        /// </summary>
        public RelayCommand CreateMigraDocDocumentsWithBuildingBlocksCommand { get; }

        /// <summary>
        /// Gibt zurück, ob <see cref="CreateMigraDocDocumentsWithBuildingBlocksCommand"/> ausgeführt werden kann.
        /// </summary>
        /// <returns><see cref="true"/>, wenn das Command ausgeführt werden kann, sonst false</returns>
        private bool CreateMigraDocDocumentsWithBuildingBlocksCanExecute()
        {
            return SerialLetterVM.Recipients.Count > 0;
        }

        /// <summary>
        /// Führt <see cref="CreateMigraDocDocumentsWithBuildingBlocksCommand"/> aus
        /// </summary>
        private void CreateMigraDocDocumentsWithBuildingBlocksExecute()
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, doWorkEventArgs) =>
                {
                    IsBusy = true;

                    Exporter.PDFsharp_MigraDoc.BriefMitBausteinen briefExporter = new Exporter.PDFsharp_MigraDoc.BriefMitBausteinen(openInViewer: OpenFilesInViewer);
                    foreach (PDFsharp_MigraDoc.ViewModels.Dokumente.Brief briefViewModel in SerialLetterVM.GetBriefVMs())
                    {
                        briefExporter.DataSource = briefViewModel;
                        briefExporter.DoExport();
                    }
                };
                worker.RunWorkerCompleted += (sender, doWorkEventArgs) =>
                {
                    IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                App.Logger.Error(ex, $"Fehler bei {nameof(CreateMigraDocDocumentsWithBuildingBlocksExecute)}\n{ex.Message}");
                IsBusy = false;
            }

        }
        #endregion CreateMigraDocDocumentsWithBuildingBlocksCommand


        #region CreateXmlCommand
        public RelayCommand CreateXmlCommand { get; }
        private bool CreateXmlCanExecute()
        {

            return SerialLetterVM.Recipients.Count > 0;
        }

        private void CreateXmlExecute()
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, doWorkEventArgs) =>
                {
                    IsBusy = true;
                    Exporter.Xml.ExporterBase<SerialLetter> exporter = new Exporter.Xml.ExporterBase<SerialLetter>(
                        dataSource: SerialLetterVM.SerialLetter, openInViewer: OpenFilesInViewer);
                    exporter.DoExport();
                };

                worker.RunWorkerCompleted += (sender, doWorkEventArgs) =>
                {
                    IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                App.Logger.Error(ex, $"Fehler bei {nameof(CreateXmlExecute)}\n{ex.Message}");
                IsBusy = false;
            }
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
            return p != null && !SerialLetterVM.SerialLetter.Recipients.Contains(p);
        }

        /// <summary>
        /// Führt <see cref="AddRecipientCommand"/> aus
        /// </summary>
        /// <param name="p">die <see cref="Person"/>, die angefügt werden soll</param>
        private void AddRecipientExecute(Person p)
        {
            SerialLetterVM.SerialLetter.Recipients.Add(p);
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
            int currentIndex = SerialLetterVM.SerialLetter.Recipients.IndexOf(SelectedRecipient);
            SerialLetterVM.SerialLetter.Recipients.Remove(SelectedRecipient);
            if (currentIndex < SerialLetterVM.SerialLetter.Recipients.Count)
            {
                SelectedRecipient = SerialLetterVM.SerialLetter.Recipients[currentIndex];
            }
            else if (SerialLetterVM.SerialLetter.Recipients.Count > 0)
            {
                SelectedRecipient = SerialLetterVM.SerialLetter.Recipients[SerialLetterVM.SerialLetter.Recipients.Count - 1];
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
