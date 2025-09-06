using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class BoolValue : IValue<bool>
    {
        [DataMember]
        public bool Value { get; set; }

        public bool Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }
    }
}
