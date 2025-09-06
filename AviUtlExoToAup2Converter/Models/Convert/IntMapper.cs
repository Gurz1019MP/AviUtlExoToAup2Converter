using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class IntMapper : IMapper
    {
        [DataMember]
        public string From { get; set; } = string.Empty;

        [DataMember]
        public string To { get; set; } = string.Empty;

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            return new IntAttribute(To, proxy.GetValue<int>(From));
        }
    }
}
