using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using System.IO;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.DAO
{
    internal static class Aup2AccessObject
    {
        #region Method

        public static void Serialize(Aup2Item aup2Item, string filePath)
        {
            List<string> contents = new();
            contents.Add("[project]");
            contents.Add($"file={filePath}");
            contents.Add("display.scene=0");

            int sceneCounter = 0;
            foreach(Scene scene in aup2Item.Scenes)
            {
                contents.Add($"[scene.{sceneCounter}]");
                contents.Add($"scene={scene.Id}");
                contents.Add($"name={scene.Name}");
                contents.Add($"video.width={scene.VideoWidth}");
                contents.Add($"video.height={scene.VideoHeight}");
                contents.Add($"video.rate={scene.VideoRate}");
                contents.Add($"video.scale={scene.VideoScale}");
                contents.Add($"audio.rate={scene.AudioRate}");
                contents.Add($"cursor.frame={scene.CursorFrame}");
                contents.Add($"display.frame={scene.DisplayFrame}");
                contents.Add($"display.layer={scene.DisplayLayer}");
                contents.Add($"display.zoom={scene.DisplayZoom}");
                contents.Add($"display.order={scene.DisplayOrder}");
                contents.Add($"display.camera={scene.DisplayCamera}");

                int objectCounter = 0;
                foreach(ObjectItem objectItem in scene.ObjectItems)
                {
                    contents.Add($"[{objectCounter}]");
                    contents.Add($"layer={objectItem.Layer}");
                    if (objectItem.IsFocus) contents.Add("focus=1");
                    contents.Add($"frame={objectItem.Frame.Start},{objectItem.Frame.End}");

                    int effectCounter = 0;
                    foreach(IEffect effect in objectItem.Effects)
                    {
                        contents.Add($"[{objectCounter}.{effectCounter}]");
                        contents.Add($"effect.name={effect.EffectName}");
                        contents.AddRange(effect.ToContentText());

                        effectCounter++;
                    }

                    objectCounter++;
                }

                sceneCounter++;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllLines(filePath, contents, new UTF8Encoding(false));
        }

        #endregion
    }
}
