using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo
{
    public class ExoItem : NotificationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rate { get; set; }
        public int Scale { get; set; }
        public int Length { get; set; }
        public int AudioRate { get; set; }
        public int AudioChannel { get; set; }
        public ObjectItem[] ObjectItems { get; set; } = [];

        public void SetProperty(string propertyName, string value)
        {
            if (propertyName == "width")
            {
                Width = int.Parse(value);
            }
            else if (propertyName == "height")
            {
                Height = int.Parse(value);
            }
            else if (propertyName == "rate")
            {
                Rate = int.Parse(value);
            }
            else if (propertyName == "scale")
            {
                Scale = int.Parse(value);
            }
            else if (propertyName == "length")
            {
                Length = int.Parse(value);
            }
            else if (propertyName == "audio_rate")
            {
                AudioRate = int.Parse(value);
            }
            else if (propertyName == "audio_ch")
            {
                AudioChannel = int.Parse(value);
            }
        }
    }
}
