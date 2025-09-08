using AviUtlExoToAup2Converter.Models;
using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.ViewModels
{
    public class SettingViewModel(Setting model) : ViewModel
    {


        private readonly Setting _model = model;
    }
}
