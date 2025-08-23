using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.Models
{
    public static class Converter
    {
        public static Aup2Item Convert(this ExoItem baseItem)
        {
            Aup2Item result = new Aup2Item();

            Scene scene = new()
            {
                Id = 0,
                Name = "Root",
                VideoWidth = baseItem.Width,
                VideoHeight = baseItem.Height,
                VideoRate = baseItem.Rate,
                VideoScale = baseItem.Scale,
                AudioRate = baseItem.AudioRate,
                CursorFrame = 0,
                DisplayFrame = 0,
                DisplayLayer = 0,
                DisplayZoom = 10000,
                DisplayOrder = 0
            };

            List<Item.Aup2.ObjectItem> newObjectItems = [];
            foreach(Item.Exo.ObjectItem baseObjectItem in baseItem.ObjectItems)
            {
                Item.Aup2.ObjectItem newObjectItem = new()
                {
                    Layer = baseObjectItem.Layer - 1,
                    Frame = new Span()
                    {
                        Start = baseObjectItem.Start,
                        End = baseObjectItem.End,
                    }
                };

                List<IEffect> effects = [];
                foreach(AbstractFilterItem filter in baseObjectItem.Filters)
                {
                    if (filter is Item.Exo.Filter.MovieFile movieFilter)
                    {
                        float start = FrameToTime(movieFilter.Position, baseItem);
                        float end = start + FrameToTime(baseObjectItem.End - (baseObjectItem.Start - 1), baseItem);
                        Item.Aup2.Effect.MovieFile effect = new()
                        {
                            PlayPosition = new SpanF() { Start = start, End = end },
                            PlaySpeed = movieFilter.Speed,
                            FilePath = movieFilter.File,
                            Track = 0,
                            IsLoop = movieFilter.Loop == 1,
                            HaveAudio = true
                        };
                        effects.Add(effect);
                    }
                    else if (filter is Item.Exo.Filter.DefaultDraw defaultDrawFilter)
                    {
                        Item.Aup2.Effect.DefaultDraw effect = new()
                        {
                            Position = new Vector3() { X = defaultDrawFilter.X, Y = defaultDrawFilter.Y, Z = defaultDrawFilter.Z },
                            Center = new Vector3(),
                            Rotate = new Vector3() { X = 0, Y = 0, Z = defaultDrawFilter.Rotate },
                            Zoom = defaultDrawFilter.Zoom,
                            Aspect = 0,
                            Alpha = defaultDrawFilter.Alpha,
                            BlendMode = (BlendMode)defaultDrawFilter.Blend,
                        };
                        effects.Add(effect);
                    }
                    else if (filter is Item.Exo.Filter.AudioFile audioFilter)
                    {
                        if (audioFilter.Alignment == 1)
                        {
                            Item.Exo.Filter.MovieFile? alimentMovieEffect = baseItem.ObjectItems.SelectMany(i => i.Filters).OfType<Item.Exo.Filter.MovieFile>().FirstOrDefault();
                            if (alimentMovieEffect != null)
                            {
                                float end = audioFilter.Position + FrameToTime(baseObjectItem.End - (baseObjectItem.Start - 1), baseItem);
                                Item.Aup2.Effect.MovieFile effect = new Item.Aup2.Effect.MovieFile()
                                {
                                    PlayPosition = new SpanF() { Start = audioFilter.Position, End = end },
                                    PlaySpeed = audioFilter.Speed,
                                    FilePath = alimentMovieEffect.File,
                                    Track = 0,
                                    IsLoop = audioFilter.Loop == 1,
                                    HaveAudio = true
                                };
                                effects.Add(effect);
                            }
                        }
                    }
                    else if (filter is Item.Exo.Filter.DefaultPlay defaultPlayFilter)
                    {
                        Item.Aup2.Effect.DefaultPlay effect = new()
                        {
                            Volume = defaultPlayFilter.Volume,
                            Pan = defaultPlayFilter.Pan,
                        };
                        effects.Add(effect);
                    }
                }
                newObjectItem.Effects = [.. effects];

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
                float frameRate = exoItem.Rate / exoItem.Scale;
                return frame / frameRate;
            }
        }
    }
}
