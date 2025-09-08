using Livet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AviUtlExoToAup2Converter.Models
{
    public class Setting : NotificationObject
    {
        #region Property

        private ConvertLogic.ConvertLogicRoot? _Logic;

        public ConvertLogic.ConvertLogicRoot? Logic
        {
            get
            { return _Logic; }
            set
            { 
                if (_Logic == value)
                    return;
                _Logic = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Method

        public void LoadLogic(string path)
        {
            DataContractSerializer serializer = new(typeof(ConvertLogic.ConvertLogicRoot));
            using var stream = new FileStream(path, FileMode.Open);
            Logic = serializer.ReadObject(stream) as ConvertLogic.ConvertLogicRoot;
        }

        #endregion
    }
}
