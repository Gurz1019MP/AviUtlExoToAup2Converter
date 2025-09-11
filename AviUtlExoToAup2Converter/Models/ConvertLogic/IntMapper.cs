using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class IntMapper : ConvertLogicBase, IMapper, ICloneable, IRemovable
    {
        private IValue<int>? _From;

        [DataMember]
        public IValue<int>? From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }

        private string? _To;

        [DataMember]
        public string? To
        {
            get
            { return _To; }
            set
            { 
                if (_To == value)
                    return;
                _To = value;
                RaisePropertyChanged();
            }
        }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            if (From == null) throw new InvalidOperationException($"Fromが設定されていません");
            if (To == null) throw new InvalidOperationException($"Toが設定されていません");

            return new IntAttribute(To, From.Invoke(proxy));
        }

        public object Clone()
        {
            return new IntMapper()
            {
                From = (From as ICloneable)?.Clone() as IValue<int>,
                To = To
            };
        }

        public void DropFrom(object obj)
        {
            if (obj is IValue<int> valueInt)
            {
                From = (valueInt as ICloneable)?.Clone() as IValue<int>;
            }
            else if (obj is IValue<Empty> valueEmpty)
            {
                From = valueEmpty.ToType<Empty, int>();
            }
        }

        public void RemoveObject(object obj)
        {
            if (From == obj)
            {
                From = null;
            }

            if (From is IRemovable removable)
            {
                removable.RemoveObject(obj);
            }
        }
    }
}
