using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SfNestedsListView
{
    public class Block : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public double NestedListHeight { get; set; }

        public double Height { get; set; }

        public int Columns { get; set; }

        public bool IsSelected { get; set; }

        public ObservableCollection<Button> Buttons { get; set; }
    }
}