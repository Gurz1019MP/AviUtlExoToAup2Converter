using System.Windows;

namespace AviUtlExoToAup2Converter.Views
{
    public class ReadOnlyProperty
    {
        public static bool GetIsReadOnly(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsReadOnlyProperty);
        }

        public static void SetIsReadOnly(DependencyObject obj, bool value)
        {
            obj.SetValue(IsReadOnlyProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.RegisterAttached("IsReadOnly", typeof(bool), typeof(ReadOnlyProperty), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
    }
}
