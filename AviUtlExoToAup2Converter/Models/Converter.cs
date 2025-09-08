using AviUtlExoToAup2Converter.Models.Convert;
using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;

namespace AviUtlExoToAup2Converter.Models
{
    public static class Converter
    {
        public static Aup2Item Convert(this ExoItem baseItem, ConvertLogicRoot logic)
        {
            Aup2Item result = new Aup2Item();

            Scene scene = new()
            {
                Attributes = [
                    new StringAttribute("name", "Root"),
                    new IntAttribute("video.width", baseItem.Attributes.GetValue<int>("width")),
                    new IntAttribute("video.height", baseItem.Attributes.GetValue<int>("height")),
                    new IntAttribute("video.rate", baseItem.Attributes.GetValue<int>("rate")),
                    new IntAttribute("video.scale", baseItem.Attributes.GetValue<int>("scale")),
                    new IntAttribute("audio.rate", baseItem.Attributes.GetValue <int>("audio_rate")),
                    new IntAttribute("cursor.frame", 0),
                    new IntAttribute("display.frame", 0),
                    new IntAttribute("display.layer", 0),
                    new IntAttribute("display.zoom", 10000),
                    new IntAttribute("display.order", 0),
                ]
            };

            List<Item.Aup2.ObjectItem> newObjectItems = [];
            foreach(Item.Exo.ObjectItem baseObjectItem in baseItem.ObjectItems)
            {
                Item.Aup2.ObjectItem newObjectItem = new()
                {
                    Attributes = [
                        new IntAttribute("layer", baseObjectItem.Attributes.GetValue<int>("layer") - 1),
                        new SpanAttribute("frame", new Span(){
                            Start = baseObjectItem.Attributes.GetValue<int>("start") - 1,
                            End = baseObjectItem.Attributes.GetValue<int>("end") - 1,
                        }),
                    ],
                    Effects = logic.FiltersToEffects(baseItem, baseObjectItem)
                };

                newObjectItems.Add(newObjectItem);
            }
            scene.ObjectItems = [.. newObjectItems];

            result.Scenes = [scene];
            return result;
        }
    }
}
