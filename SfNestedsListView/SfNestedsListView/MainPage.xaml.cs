using Syncfusion.DataSource.Extensions;
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

        private void ButtonsList_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            var buttonsListView = sender as SfListView;
            var displayItems = buttonsListView.DataSource.DisplayItems.Where(o => (o as GroupResult) != null);
            buttonsListView.LayoutManager = new GridLayout() { SpanCount = displayItems.Max(o => (o as GroupResult).Items.ToList<object>().Count()) };
        }
    }
}
