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
    public class MovieFileViewModel(MovieFile model) : AbstractFilterItemViewModel(model)
    {
        #region Property

        public override string Name => _model.Name;
        public int Position => _model.Position;
        public float Speed => _model.Speed;
        public byte Loop => _model.Loop;
        public byte Alpha => _model.Alpha;
        public string File => _model.File;

        #endregion

        #region Field

        private readonly MovieFile _model = model;

        #endregion
    }
}
