using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public abstract class AbstractFilterItemViewModel(AbstractFilterItem model) : ViewModel
    {
        #region Property

        public abstract string Name { get; }

        #endregion

        #region Field

        private readonly AbstractFilterItem _model = model;
        
        #endregion
    }
}
