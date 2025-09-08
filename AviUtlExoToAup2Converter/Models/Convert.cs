using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item;
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
            DataContractSerializer serializer = new(typeof(ConvertLogic.ConvertLogicRoot));
            using var stream = new FileStream(path, FileMode.Open);
            Logic = serializer.ReadObject(stream) as ConvertLogic.ConvertLogicRoot;
        }

        public void Invoke()
        {
            if (ExoItem == null) throw new ArgumentNullException();
            if (Logic == null) throw new ArgumentNullException();

            Aup2Item result = new();

            Scene scene = new()
            {
                Attributes = [
                    new StringAttribute("name", "Root"),
                    new IntAttribute("video.width", ExoItem.Attributes.GetValue<int>("width")),
                    new IntAttribute("video.height", ExoItem.Attributes.GetValue<int>("height")),
                    new IntAttribute("video.rate", ExoItem.Attributes.GetValue<int>("rate")),
                    new IntAttribute("video.scale", ExoItem.Attributes.GetValue<int>("scale")),
                    new IntAttribute("audio.rate", ExoItem.Attributes.GetValue <int>("audio_rate")),
                    new IntAttribute("cursor.frame", 0),
                    new IntAttribute("display.frame", 0),
                    new IntAttribute("display.layer", 0),
                    new IntAttribute("display.zoom", 10000),
                    new IntAttribute("display.order", 0),
                ]
            };

            List<Item.Aup2.ObjectItem> newObjectItems = [];
            foreach (Item.Exo.ObjectItem baseObjectItem in ExoItem.ObjectItems)
            {
                Item.Aup2.ObjectItem newObjectItem = new()
                {
                    Attributes = [
                        new IntAttribute("layer", baseObjectItem.Attributes.GetValue<int>("layer") - 1),
                        new SpanAttribute("frame", new Span(){
                            Start = baseObjectItem.Attributes.GetValue<int>("start") - 1,
                            End = baseObjectItem.Attributes.GetValue<int>("end") - 1,
                        }),
                    ],
                    Effects = Logic.FiltersToEffects(ExoItem, baseObjectItem)
                };

                newObjectItems.Add(newObjectItem);
            }
            scene.ObjectItems = [.. newObjectItems];

            result.Scenes = [scene];

            Aup2Item = result;
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
