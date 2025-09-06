using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class BlendModeValue : IValue<string>
    {
        [DataMember]
        public required IValue<int> Value { get; set; }

        public string Invoke(Dictionary<string, object> proxy)
        {
            return ((BlendMode)Value.Invoke(proxy)).ToString();
        }
    }
}
