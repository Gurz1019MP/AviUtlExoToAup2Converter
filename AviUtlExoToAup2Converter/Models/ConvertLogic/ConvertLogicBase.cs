using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class ConvertLogicBase : NotificationObject
    {
        public class ReplaceModelEventArgs(object model) : EventArgs
        {
            public object Model { get; } = model;
        }

        public event EventHandler<ReplaceModelEventArgs>? ReplaceModel;

        protected void RaiseReplaceModel(object model)
        {
            ReplaceModel?.Invoke(this, new ReplaceModelEventArgs(model));
        }
    }
}
