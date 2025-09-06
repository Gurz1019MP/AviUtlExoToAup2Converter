using AviUtlExoToAup2Converter.Models.Item;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    public class PlayPositionMapper : IMapper
    {
        [DataMember]
        public string To { get; set; } = string.Empty;

        public required IValue<float> Start { get; set; }

        public required IValue<float> End {  get; set; }

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
