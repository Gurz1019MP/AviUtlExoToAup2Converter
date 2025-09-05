using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using System.IO;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.DAO
{
    internal static class Aup2AccessObject
    {
        #region Method

        public static void Serialize(Aup2Item aup2Item, string filePath)
        {
            List<string> contents = [
                "[project]",
                $"file={filePath}",
                "display.scene=0"
            ];

            int sceneCounter = 0;
            foreach(Scene scene in aup2Item.Scenes)
            {
                contents.Add($"[scene.{sceneCounter}]");
                contents.Add($"scene={sceneCounter}");
                foreach (IAttribute attribute in scene.Attributes)
                {
                    contents.Add($"{attribute.Name}={attribute.ValueString}");
                }
                contents.Add("display.camera=");

                int objectCounter = 0;
                foreach(ObjectItem objectItem in scene.ObjectItems)
                {
                    contents.Add($"[{objectCounter}]");
                    foreach (IAttribute attribute in objectItem.Attributes)
                    {
                        contents.Add($"{attribute.Name}={attribute.ValueString}");
                    }

                    int effectCounter = 0;
                    foreach(GeneralEffect effect in objectItem.Effects)
                    {
                        contents.Add($"[{objectCounter}.{effectCounter}]");
                        contents.Add($"effect.name={effect.Name}");
                        foreach (IAttribute attribute in effect.Attributes)
                        {
                            contents.Add($"{attribute.Name}={attribute.ValueString}");
                        }

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
