using AviUtlExoToAup2Converter.Models.DAO;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class IntValue : ConvertLogicBase, IValue<int>, ICloneable
    {
        private int _Value;

        [DataMember]
        public int Value
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

        public int Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }

        public object Clone()
        {
            return new IntValue()
            {
                Value = Value
            };
        }
    }
}
