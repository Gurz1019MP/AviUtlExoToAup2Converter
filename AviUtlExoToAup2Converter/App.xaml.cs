using Livet;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace AviUtlExoToAup2Converter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherHelper.UIDispatcher = Dispatcher.CurrentDispatcher;
        }
    }

}
