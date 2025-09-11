using AviUtlExoToAup2Converter.Models.DAO;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class StringValue : ConvertLogicBase, IValue<string>, ICloneable
    {
        private string? _Value;

        [DataMember]
        public string? Value
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
            return Value == null ? string.Empty : Value;
        }

        public object Clone()
        {
            return new StringValue()
            {
                Value = Value
            };
        }
    }
}
