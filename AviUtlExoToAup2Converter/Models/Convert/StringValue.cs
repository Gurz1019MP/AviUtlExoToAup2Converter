using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class StringValue : IValue<string>
    {
        [DataMember]
        public string Value { get; set; } = string.Empty;

        public string Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }
    }
}
