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
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public class DefaultPlayViewModel(DefaultPlay model) : AbstractFilterItemViewModel(model)
    {
        #region Property

        public override string Name => _model.Name;
        public float Volume => _model.Volume;
        public float Pan => _model.Pan;

        #endregion

        #region Field

        private readonly DefaultPlay _model = model;

        #endregion
    }
}
