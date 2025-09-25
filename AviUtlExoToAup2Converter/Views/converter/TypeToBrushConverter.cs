using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AviUtlExoToAup2Converter.Views.converter
{
    internal class TypeToBrushConverter : IValueConverter
    {
        public Brush? IntBrush { get; set; }
        public Brush? FloatBrush { get; set; }
        public Brush? StringBrush { get; set; }
        public Brush? EmptyBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type valueType = value.GetType();
            if (!valueType.IsGenericType) return EmptyBrush!;
            Type genericType = valueType.GetGenericArguments()[0];
            if (genericType == typeof(int))
            {
                return IntBrush!;
            }
            else if (genericType == typeof(float))
            {
                return FloatBrush!;
            }
            else if (genericType == typeof(string))
            {
                return StringBrush!;
            }
            else
            {
                return EmptyBrush!;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
