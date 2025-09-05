using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class Scene2 : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];
        public ObjectItem2[] ObjectItems { get; set; } = [];
    }
}
