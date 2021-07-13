using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SfNestedsListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private void buttonsListView_ItemAppearing(object sender, ItemAppearingEventArgs e)
        {
            var listView = sender as SfListView;
            listView.RefreshListViewItem();
            ((MainViewModel)BindingContext).RefreshNestedListHeight();
        }
    }
}
