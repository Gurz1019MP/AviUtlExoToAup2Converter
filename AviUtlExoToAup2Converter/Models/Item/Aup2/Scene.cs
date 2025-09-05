using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class Scene : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];
        public ObjectItem[] ObjectItems { get; set; } = [];
    }
}
