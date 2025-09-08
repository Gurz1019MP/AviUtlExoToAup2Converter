using AviUtlExoToAup2Converter.Models.Convert;
using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AviUtlExoToAup2Converter.Models
{
    public class MainModel : NotificationObject
    {
        #region Property

        private ExoItem? _ExoItem2;

        public ExoItem? ExoItem2
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

        private Aup2Item? _Aup2Item2;

        public Aup2Item? Aup2Item2
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
            ExoItem2 = ExoAccessObject.Deserialize(path);
        }

        public void Convert(string path)
        {
            if (ExoItem2 == null) throw new ArgumentNullException();

            ConvertLogicRoot? logic = null;
            DataContractSerializer serializer = new DataContractSerializer(typeof(Convert.ConvertLogicRoot));
            using (var stream = new FileStream(Path.ChangeExtension(path, "xml"), FileMode.Open))
            {
                 logic = serializer.ReadObject(stream) as ConvertLogicRoot;
            }

            if (logic != null)
            {
                Aup2Item2 = ExoItem2.Convert(logic);
            }
        }

        public void Export(string path)
        {
            if (Aup2Item2 == null) throw new ArgumentNullException();
            Aup2AccessObject.Serialize(Aup2Item2, path);

            DataContractSerializer serializer = new DataContractSerializer(typeof(Convert.ConvertLogicRoot));
            using (var stream = new FileStream(Path.ChangeExtension(path, "xml"), FileMode.OpenOrCreate ))
            {
                using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
                {
                    serializer.WriteObject(writer, Models.Convert.ConvertLogicRoot.DevLogic);
                }
            }
        }

        #endregion
    }
}
