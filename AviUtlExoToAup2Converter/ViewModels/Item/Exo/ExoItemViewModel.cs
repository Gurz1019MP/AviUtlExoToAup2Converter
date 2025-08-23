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
using AviUtlExoToAup2Converter.Models.Item.Exo;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ExoItemViewModel : ViewModel
    {
        #region .ctor

        public ExoItemViewModel(ExoItem model)
        {
            _model = model;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItemViewModel>()];
        }

        #endregion

        #region Property

        public int Width => _model.Width;
        public int Height => _model.Height;
        public int Rate => _model.Rate;
        public int Scale => _model.Scale;
        public int Length => _model.Length;
        public int AudioRate => _model.AudioRate;
        public int AudioChannel => _model.AudioChannel;
        public ObjectItemViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly ExoItem _model;

        #endregion
    }
}
