using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AviUtlExoToAup2Converter.Views
{
    public class ConvertLogicTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            try
            {
                return (DataTemplate)Application.Current.FindResource(item?.GetType().Name);
            }
            catch(Exception e)
            {
                return base.SelectTemplate(item, container);
            }
        }
    }
}
