using AviUtlExoToAup2Converter.Models.Item.Exo;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class FindFirstFilterByName : IValue<GeneralFilter>
    {
        [DataMember]
        public required string Name { get; set; }

        public GeneralFilter? Invoke(Dictionary<string, object> proxy)
        {
            ExoItem? target = proxy["baseItem"] as ExoItem;
            if (target == null) return null;

            return target.ObjectItems.SelectMany(i => i.Filters).FirstOrDefault(f => f.Name == Name);
        }
    }
}
