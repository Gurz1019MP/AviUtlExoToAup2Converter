using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo
{
    public class ExoItem : NotificationObject
    {
        public IAttribute[] Attributes { get; set; } = [];

        public ObjectItem[] ObjectItems { get; set; } = [];
    }
}
