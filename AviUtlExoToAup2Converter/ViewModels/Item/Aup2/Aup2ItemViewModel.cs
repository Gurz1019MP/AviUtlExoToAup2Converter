using AviUtlExoToAup2Converter.Models.Item.Aup2;
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

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class Aup2ItemViewModel : ViewModel
    {
        #region .ctor

        public Aup2ItemViewModel(Aup2Item model)
        {
            _model = model;
            Scenes = [.. _model.Scenes.CreateViewModels().Cast<SceneViewModel>()];
        }

        #endregion

        #region Property

        public SceneViewModel[] Scenes { get; }

        #endregion

        #region Field

        private readonly Aup2Item _model;

        #endregion
    }
}
