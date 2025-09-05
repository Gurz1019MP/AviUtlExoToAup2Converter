using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public class GeneralEffect(string name, IAttribute[] attributes) : NotificationObject
    {
        public string Name { get; set; } = name;

        public IAttribute[] Attributes { get; set; } = attributes;
    }
}
