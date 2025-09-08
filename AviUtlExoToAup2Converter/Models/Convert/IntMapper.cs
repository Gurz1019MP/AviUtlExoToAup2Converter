using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class IntMapper : IMapper
    {
        [DataMember]
        public required IValue<int> From { get; set; }

        [DataMember]
        public required string To { get; set; }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            return new IntAttribute(To, From.Invoke(proxy));
        }
    }
}
