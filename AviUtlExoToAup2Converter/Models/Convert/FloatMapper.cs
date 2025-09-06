using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class FloatMapper : IMapper
    {
        [DataMember]
        public string From { get; set; } = string.Empty;

        [DataMember]
        public string To { get; set; } = string.Empty;

        [DataMember]
        public string Format {  get; set; } = string.Empty;

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            return new FloatAttribute(To, proxy.GetValue<float>(From), Format);
        }
    }
}
