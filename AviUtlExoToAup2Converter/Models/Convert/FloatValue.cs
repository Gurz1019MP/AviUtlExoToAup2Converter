using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class FloatValue : IValue<float>
    {
        [DataMember]
        public float Value { get; set; }

        public float Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }
    }
}
