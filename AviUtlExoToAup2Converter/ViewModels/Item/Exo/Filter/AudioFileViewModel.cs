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
    public class AudioFileViewModel(AudioFile model) : AbstractFilterItemViewModel(model)
    {
        #region Property

        public override string Name => _model.Name;
        public float Position => _model.Position;
        public float Speed => _model.Speed;
        public byte Loop => _model.Loop;
        public int Alignment => _model.Alignment;
        public string File => _model.File;
        
        #endregion

        #region Field

        private readonly AudioFile _model = model;
        
        #endregion
    }
}
