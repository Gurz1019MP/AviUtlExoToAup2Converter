using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class StringMapper : IMapper
    {
        [DataMember]
        public required IValue<string> From { get; set; }

        [DataMember]
        public required string To { get; set; }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            string? value = From.Invoke(proxy);
            if (value == null)
            {
                value = string.Empty;
            }
            return new StringAttribute(To, value);
        }
    }
}
