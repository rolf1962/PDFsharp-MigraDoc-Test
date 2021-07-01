using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PDFsharp_MigraDoc.WpfApp.Models
{
    public class SerialLetter : ModelBase
    {
        private Person sender;
        private string text;

        public Person Sender
        {
            get => sender; set
            {
                if (sender != value)
                {
                    sender = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Text
        {
            get => text; set
            {
                if (Text != value)
                {
                    text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Person> Recipients { get; set; } = new ObservableCollection<Person>();
    }
}
