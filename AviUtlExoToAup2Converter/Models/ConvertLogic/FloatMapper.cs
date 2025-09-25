using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class FloatMapper : ConvertLogicBase, IMapper, ICloneable, IRemovable
    {
        private IValue<float>? _From;

        [DataMember]
        public IValue<float>? From
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

        private string? _Format;

        [DataMember]
        public string? Format
        {
            get
            { return _Format; }
            set
            { 
                if (_Format == value)
                    return;
                _Format = value;
                RaisePropertyChanged();
            }
        }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            if (From == null) throw new InvalidOperationException("Fromが設定されていません");
            if (To == null) throw new InvalidOperationException("Toが設定されていません");
            if (Format == null) throw new InvalidOperationException("Formatが設定されていません");

            return new FloatAttribute(To, From.Invoke(proxy), Format);
        }

        public object Clone()
        {
            return new FloatMapper()
            {
                From = (From as ICloneable)?.Clone() as IValue<float>,
                To = To,
                Format = Format,
            };
        }

        public void DropFrom(object obj)
        {
            if (obj is IValue<float> valueFloat)
            {
                From = (valueFloat as ICloneable)?.Clone() as IValue<float>;
            }
            else if (obj is IValue<Empty> valueEmpty)
            {
                From = valueEmpty.ToType<Empty, float>();
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
