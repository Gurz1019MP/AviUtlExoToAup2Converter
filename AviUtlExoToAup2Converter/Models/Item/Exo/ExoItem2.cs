using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo
{
    public class ExoItem2 : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];

        public ObjectItem2[] ObjectItems { get; set; } = [];
    }
}
