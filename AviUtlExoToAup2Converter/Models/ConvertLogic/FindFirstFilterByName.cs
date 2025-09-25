using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class FindFirstFilterByName : ConvertLogicBase, IValue<GeneralFilter>, ICloneable
    {
        private string? _Name;

        [DataMember]
        public string? Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }

        public GeneralFilter? Invoke(Dictionary<string, object> proxy)
        {
            if (proxy["baseItem"] is not ExoItem target) return null;

            return target.ObjectItems.SelectMany(i => i.Filters).FirstOrDefault(f => f.Name == Name);
        }

        public object Clone()
        {
            return new FindFirstFilterByName()
            {
                Name = Name
            };
        }
    }
}
