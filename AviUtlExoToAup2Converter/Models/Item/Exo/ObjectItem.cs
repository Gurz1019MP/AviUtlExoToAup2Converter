using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo
{
    public class ObjectItem : NotificationObject
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Layer { get; set; }
        public byte Overlay { get; set; }
        public byte Audio { get; set; }
        public byte Camera { get; set; }
        public AbstractFilterItem[] Filters { get; set; }

        public void SetProperty(string propertyName, string value)
        {
            if (propertyName == "start")
            {
                Start = int.Parse(value);
            }
            else if (propertyName == "end")
            {
                End = int.Parse(value);
            }
            else if (propertyName == "layer")
            {
                Layer = int.Parse(value);
            }
            else if (propertyName == "overlay")
            {
                Overlay = byte.Parse(value);
            }
            else if (propertyName == "audio")
            {
                Audio = byte.Parse(value);
            }
            else if (propertyName == "camera")
            {
                Camera = byte.Parse(value);
            }
        }
    }
}
