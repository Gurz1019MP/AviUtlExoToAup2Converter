using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.Models
{
    public class MainModel : NotificationObject
    {
        #region Property

        private ExoItem? _ExoItem;

        public ExoItem? ExoItem
        {
            get
            { return _ExoItem; }
            set
            { 
                if (_ExoItem == value)
                    return;
                _ExoItem = value;
                RaisePropertyChanged();
            }
        }

        private Aup2Item? _Aup2Item;

        public Aup2Item? Aup2Item
        {
            get
            { return _Aup2Item; }
            set
            { 
                if (_Aup2Item == value)
                    return;
                _Aup2Item = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Method

        public void Import(string path)
        {
            ExoItem = ExoAccessObject.Deserialize(path);
        }

        public void Convert()
        {
            if (ExoItem == null) throw new ArgumentNullException();
            Aup2Item = ExoItem.Convert();
        }

        public void Export(string path)
        {
            if (Aup2Item == null) throw new ArgumentNullException();
            Aup2AccessObject.Serialize(Aup2Item, path);
        }

        #endregion
    }
}
