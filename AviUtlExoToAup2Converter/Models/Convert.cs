using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AviUtlExoToAup2Converter.Models
{
    public class Convert : NotificationObject
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

        private ConvertLogic.ConvertLogicRoot? _Logic = ConvertLogic.ConvertLogicRoot.DevLogic;

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

        public void LoadLogic(string path)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(ConvertLogic.ConvertLogicRoot));
            using var stream = new FileStream(path, FileMode.Open);
            Logic = serializer.ReadObject(stream) as ConvertLogic.ConvertLogicRoot;
        }

        public void Invoke()
        {
            if (ExoItem == null) throw new ArgumentNullException();
            if (Logic == null) throw new ArgumentNullException();
            Aup2Item = ExoItem.Convert(Logic);
        }

        public void Export(string path)
        {
            if (Aup2Item == null) throw new ArgumentNullException();
            Aup2AccessObject.Serialize(Aup2Item, path);

            //DataContractSerializer serializer = new DataContractSerializer(typeof(ConvertLogic.ConvertLogicRoot));
            //using (var stream = new FileStream(Path.ChangeExtension(path, "xml"), FileMode.OpenOrCreate))
            //{
            //    using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
            //    {
            //        serializer.WriteObject(writer, Models.ConvertLogic.ConvertLogicRoot.DevLogic);
            //    }
            //}
        }

        #endregion
    }
}
