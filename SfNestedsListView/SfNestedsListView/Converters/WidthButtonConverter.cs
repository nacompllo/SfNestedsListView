using Syncfusion.ListView.XForms;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SfNestedsListView.Converters
{
    public class WidthButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listView = parameter as SfListView;

            var listViewWidth = listView.Width;
            var botonAnchoPorcentage = (double)value;

            var anchoBoton = listViewWidth * botonAnchoPorcentage / 100;
            return anchoBoton;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}