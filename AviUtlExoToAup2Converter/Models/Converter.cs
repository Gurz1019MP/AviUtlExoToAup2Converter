using AviUtlExoToAup2Converter.Models.Convert;
using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;

namespace AviUtlExoToAup2Converter.Models
{
    public static class Converter
    {
        public static Aup2Item Convert(this ExoItem baseItem)
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
                    ]
                };

                ConvertLogicRoot logic = ConvertLogicRoot.DevLogic;
                newObjectItem.Effects = logic.FiltersToEffects(baseItem, baseObjectItem);

                //List<GeneralEffect> effects = [];
                //foreach(GeneralFilter filter in baseObjectItem.Filters)
                //{
                    //if (filter.Name == "動画ファイル")
                    //{
                    //    GeneralEffect effect = new("動画ファイル", [
                    //        new PlayPositionAttribute("再生位置", new PlayPosition(){
                    //            Start = FrameToTime(filter.Attributes.GetValue<int>("再生位置"), baseItem),
                    //            End = FrameToTime(filter.Attributes.GetValue<int>("再生位置"), baseItem) + FrameToTime(baseObjectItem.Attributes.GetValue<int>("end") - (baseObjectItem.Attributes.GetValue<int>("start") - 1), baseItem),
                    //            Range = 0
                    //        }),
                    //        new FloatAttribute("再生速度", filter.Attributes.GetValue<float>("再生速度"), "F2"),
                    //        new StringAttribute("ファイル", filter.Attributes.GetValue<string>("file")),
                    //        new IntAttribute("ループ再生", filter.Attributes.GetValue<int>("ループ再生") ),
                    //        new IntAttribute("音声付き", 1),
                    //    ]);
                    //    effects.Add(effect);
                    //}
                    //else if (filter.Name == "標準描画")
                    //{
                    //    GeneralEffect effect = new("映像再生", [
                    //        new FloatAttribute("X", filter.Attributes.GetValue<float>("X"), "F2"),
                    //        new FloatAttribute("Y", filter.Attributes.GetValue<float>("Y"), "F2"),
                    //        new FloatAttribute("Z", filter.Attributes.GetValue<float>("Z"), "F2"),
                    //        new FloatAttribute("中心X", 0, "F2"),
                    //        new FloatAttribute("中心Y", 0, "F2"),
                    //        new FloatAttribute("中心Z", 0, "F2"),
                    //        new FloatAttribute("X軸回転", 0, "F2"),
                    //        new FloatAttribute("Y軸回転", 0, "F2"),
                    //        new FloatAttribute("Z軸回転", filter.Attributes.GetValue<float>("回転"), "F2"),
                    //        new FloatAttribute("拡大率", filter.Attributes.GetValue<float>("拡大率"), "F3"),
                    //        new FloatAttribute("縦横比", 0, "F3"),
                    //        new FloatAttribute("透明度", filter.Attributes.GetValue<float>("透明度"), "F2"),
                    //        new StringAttribute("合成モード", ((BlendMode)filter.Attributes.GetValue<int>("blend")).ToString())
                    //    ]);
                    //    effects.Add(effect);
                    //}
                    //else if (filter.Name == "音声ファイル")
                    //{
                    //    if (filter.Attributes.GetValue<int>("動画ファイルと連携") == 1)
                    //    {
                    //        GeneralFilter? alimentMoviefilter = baseItem.ObjectItems.SelectMany(i => i.Filters).FirstOrDefault(f => f.Name == "動画ファイル");
                    //        if (alimentMoviefilter != null)
                    //        {
                    //            GeneralEffect effect = new("動画ファイル", [
                    //                new PlayPositionAttribute("再生位置", new PlayPosition(){
                    //                    Start = filter.Attributes.GetValue<float>("再生位置"),
                    //                    End = filter.Attributes.GetValue<float>("再生位置") + FrameToTime(baseObjectItem.Attributes.GetValue<int>("end") - (baseObjectItem.Attributes.GetValue<int>("start") - 1), baseItem),
                    //                    Range = 0
                    //                }),
                    //                new FloatAttribute("再生速度", filter.Attributes.GetValue<float>("再生速度"), "F2"),
                    //                new StringAttribute("ファイル", alimentMoviefilter.Attributes.GetValue<string>("file")),
                    //                new IntAttribute("トラック", 0),
                    //                new IntAttribute("ループ再生", filter.Attributes.GetValue<int>("ループ再生") ),
                    //                new IntAttribute("音声付き", 1),
                    //            ]);
                    //            effects.Add(effect);
                    //        }
                    //    }
                    //}
                    //else if (filter.Name == "標準再生")
                    //{
                    //    GeneralEffect effect = new("音声再生", [
                    //        new FloatAttribute("音量", filter.Attributes.GetValue<float>("音量"), "F2"),
                    //        new FloatAttribute("左右", filter.Attributes.GetValue<float>("左右"), "F2"),
                    //    ]);
                    //    effects.Add(effect);
                    //}
                //}
                //newObjectItem.Effects = [.. effects];

                newObjectItems.Add(newObjectItem);
            }
            scene.ObjectItems = [.. newObjectItems];

            result.Scenes = [scene];
            return result;
        }

        private static float FrameToTime(int frame, ExoItem exoItem)
        {
            if (frame == 1)
            {
                return 0f;
            }
            else
            {
                float frameRate = exoItem.Attributes.GetValue<int>("rate") / exoItem.Attributes.GetValue<int>("scale");
                return frame / frameRate;
            }
        }
    }
}
