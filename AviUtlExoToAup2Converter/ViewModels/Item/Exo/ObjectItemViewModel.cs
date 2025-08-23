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
using AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ObjectItemViewModel : ViewModel
    {
        #region .ctor
        public ObjectItemViewModel(ObjectItem model)
        {
            _model = model;
            Filters = [.. _model.Filters.CreateViewModels().Cast<AbstractFilterItemViewModel>()];
        }
        #endregion

        #region Property
        public int Start => _model.Start;
        public int End => _model.End;
        public int Layer => _model.Layer;
        public byte Overlay => _model.Overlay;
        public byte Audio => _model.Audio;
        public byte Camera => _model.Camera;
        public AbstractFilterItemViewModel[] Filters { get; }
        #endregion

        #region Field

        private readonly ObjectItem _model;

        #endregion
    }
}
