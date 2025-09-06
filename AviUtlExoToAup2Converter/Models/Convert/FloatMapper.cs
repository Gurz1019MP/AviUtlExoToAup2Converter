using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class FloatMapper : IMapper
    {
        [DataMember]
        public required IValue<float> From { get; set; }

        [DataMember]
        public required string To { get; set; }

        [DataMember]
        public required string Format {  get; set; }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            return new FloatAttribute(To, From.Invoke(proxy), Format);
        }
    }
}
