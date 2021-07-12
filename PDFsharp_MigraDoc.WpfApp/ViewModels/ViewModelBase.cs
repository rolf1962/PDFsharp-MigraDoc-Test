﻿namespace PDFsharp_MigraDoc.WpfApp.ViewModels
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }
    }
}
