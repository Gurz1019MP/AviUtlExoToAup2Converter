using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class BlendModeValue : ConvertLogicBase, IValue<string>, ICloneable, IRemovable
    {
        private IValue<int>? _Value;

        [DataMember]
        public IValue<int>? Value
        {
            get
            { return _Value; }
            set
            { 
                if (_Value == value)
                    return;
                _Value = value;
                RaisePropertyChanged();
            }
        }

        public string Invoke(Dictionary<string, object> proxy)
        {
            if (Value == null) throw new InvalidOperationException("Valueが設定されていません");
            return ((BlendMode)Value.Invoke(proxy)).ToString();
        }

        public object Clone()
        {
            return new BlendModeValue()
            {
                Value = (Value as ICloneable)?.Clone() as IValue<int>
            };
        }

        public void DropValue(object obj)
        {
            if (obj is IValue<int> valueInt)
            {
                Value = (valueInt as ICloneable)?.Clone() as IValue<int>;
            }
        }

        public void RemoveObject(object obj)
        {
            if (Value == obj)
            {
                Value = null;
            }

            if (Value is IRemovable removable)
            {
                removable.RemoveObject(this);
            }
        }
    }
}
