using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class ObjectItem2 : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];
        public GeneralEffect[] Effects { get; set; } = [];
    }
}
