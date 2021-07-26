using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SfNestedsListView
{
    public class ExtendedListView : SfListView
    {

        VisualContainer container;

        public ExtendedListView()
        {
            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.macOS)
            {
                this.container = this.GetVisualContainer();
                this.DataSource.SourceCollectionChanged += DataSource_SourceCollectionChanged;
                this.container.PropertyChanged += Container_PropertyChanged;
            }
        }

        private void Container_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var extent = (double)container.GetType().GetRuntimeProperties().FirstOrDefault(container => container.Name == "TotalExtent").GetValue(container);
                if (e.PropertyName == "Height")
                    this.HeightRequest = extent;

                var displayItems = this.DataSource.DisplayItems.Where(o => (o as GroupResult) != null);
                if (displayItems.Any())
                {
                    var size = this.Width / this.ItemSize;
                    this.LayoutManager = new GridLayout() { SpanCount = (int)size };
                }
            });
        }

        private void DataSource_SourceCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var totalextent = (double)container.GetType().GetRuntimeProperties().FirstOrDefault(container => container.Name == "TotalExtent").GetValue(container);
                this.HeightRequest = totalextent;

                var displayItems = this.DataSource.DisplayItems.Where(o => (o as GroupResult) != null);
                if (displayItems.Any())
                {
                    var size = this.Width / this.ItemSize;
                    this.LayoutManager = new GridLayout() { SpanCount = (int)size };
                }
            });
        }   
    }
}
