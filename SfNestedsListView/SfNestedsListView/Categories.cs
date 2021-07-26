using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SfNestedsListView
{
    public class Categories : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public ObservableCollection<Block> Blocks { get; set; }
    }
}
