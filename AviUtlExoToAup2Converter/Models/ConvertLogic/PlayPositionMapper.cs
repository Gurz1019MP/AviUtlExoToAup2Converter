using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class PlayPositionMapper : IMapper
    {
        [DataMember]
        public string To { get; set; } = string.Empty;

        [DataMember]
        public required IValue<float> Start { get; set; }

        [DataMember]
        public required IValue<float> End {  get; set; }

        [DataMember]
        public required IValue<int> Range { get; set; }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            return new PlayPositionAttribute(To, new PlayPosition()
            {
                Start = Start.Invoke(proxy),
                End = End.Invoke(proxy),
                Range = Range.Invoke(proxy),
            });
        }
    }
}
