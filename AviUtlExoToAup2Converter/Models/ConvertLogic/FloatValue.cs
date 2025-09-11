using AviUtlExoToAup2Converter.Models.DAO;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class FloatValue : ConvertLogicBase, IValue<float>, ICloneable
    {
        private float _Value;

        [DataMember]
        public float Value
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

        public float Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }

        public object Clone()
        {
            return new FloatValue()
            {
                Value = Value
            };
        }
    }
}
