using System.ComponentModel;

namespace SfNestedsListView
{
    public class Button : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public string Group { get; set; }

        public bool IsSelected { get; set; }
    }
}