using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo
{
    public class ObjectItem : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];

        public GeneralFilter[] Filters { get; set; } = [];
    }
}
