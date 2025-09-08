using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class StringValue : IValue<string>
    {
        [DataMember]
        public required string Value { get; set; }

        public string Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }
    }
}
