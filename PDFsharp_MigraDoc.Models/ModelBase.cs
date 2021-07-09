using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PDFsharp_MigraDoc.Models
{
    /// <summary>
    /// Die abstrakte Basisklasse für Models.
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region Implementierung von INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Implementierung von INotifyPropertyChanged
    }
}
