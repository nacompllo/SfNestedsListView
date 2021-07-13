using System.ComponentModel;

namespace SfNestedsListView
{
    public class Button : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public double Height { get; set; }

        public bool IsSelected { get; set; }
    }
}