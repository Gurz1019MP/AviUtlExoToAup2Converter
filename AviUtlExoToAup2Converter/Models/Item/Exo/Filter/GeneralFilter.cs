using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public class GeneralFilter(string name, IAttribute[] attributes) : NotificationObject
    {
        public string Name { get; set; } = name;

        public IAttribute[] Attributes { get; set; } = attributes;
    }
}
