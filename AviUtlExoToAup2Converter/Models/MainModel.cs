using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.Models
{
    public class MainModel : NotificationObject
    {
        #region Property

        private ExoItem2? _ExoItem2;

        public ExoItem2? ExoItem2
        {
            get
            { return _ExoItem2; }
            set
            {
                if (_ExoItem2 == value)
                    return;
                _ExoItem2 = value;
                RaisePropertyChanged();
            }
        }

        private Aup2Item2? _Aup2Item2;

        public Aup2Item2? Aup2Item2
        {
            get
            { return _Aup2Item2; }
            set
            {
                if (_Aup2Item2 == value)
                    return;
                _Aup2Item2 = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Method

        public void Import(string path)
        {
            //ExoItem = ExoAccessObject.Deserialize(path);
            ExoItem2 = ExoAccessObject2.Deserialize(path);
        }

        public void Convert()
        {
            if (ExoItem2 == null) throw new ArgumentNullException();
            Aup2Item2 = ExoItem2.Convert();
        }

        public void Export(string path)
        {
            if (Aup2Item2 == null) throw new ArgumentNullException();
            Aup2AccessObject2.Serialize(Aup2Item2, path);
        }

        #endregion
    }
}
