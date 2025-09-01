using AviUtlExoToAup2Converter.Models.Item.Exo;
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AviUtlExoToAup2Converter.Models.DAO
{
    internal static class ExoAccessObject
    {
        #region Method

        public static void Serialize(ExoItem exoItem, string filePath)
        {
            List<string> contents = new();
            contents.Add("[exedit]");
            contents.Add($"width={exoItem.Width}");
            contents.Add($"height={exoItem.Height}");
            contents.Add($"rate={exoItem.Rate}");
            contents.Add($"scale={exoItem.Scale}");
            contents.Add($"length={exoItem.Length}");
            contents.Add($"audio_rate={exoItem.AudioRate}");
            contents.Add($"audio_ch={exoItem.AudioChannel}");

            int objectCounter = 0;
            foreach (ObjectItem objectItem in exoItem.ObjectItems)
            {
                contents.Add($"[{objectCounter}]");
                contents.Add($"start={objectItem.Start}");
                contents.Add($"end={objectItem.End}");
                contents.Add($"layer={objectItem.Layer}");
                contents.Add($"overlay={objectItem.Overlay}");
                contents.Add($"audio={objectItem.Audio}");
                contents.Add($"camera={objectItem.Camera}");

                int filterCounter = 0;
                foreach (AbstractFilterItem filterItem in objectItem.Filters)
                {
                    contents.Add($"[{objectCounter}.{filterCounter}]");
                    contents.Add($"_name={filterItem.Name}");
                    contents.AddRange(filterItem.ToContentText());

                    filterCounter++;
                }

                objectCounter++;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllLines(filePath, contents, Encoding.GetEncoding("shift_jis"));
        }

        public static ExoItem? Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            ExoItem result = new();
            List<ObjectItem> objectItems = new();
            ObjectItem objectItem = null;
            List<AbstractFilterItem> filterItems = new();
            AbstractFilterItem filterItem = null;
            ReadMode mode = ReadMode.Exo;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            foreach (string line in File.ReadLines(filePath, Encoding.GetEncoding("shift_jis")))
            {
                if (_objectNumberRegex.IsMatch(line))
                {
                    Match match = _objectNumberRegex.Match(line);
                    string number = match.Groups["number"].Value;

                    if (number == "exedit")
                    {
                        mode = ReadMode.Exo;
                    }
                    else if (int.TryParse(number, out int objectNumber))
                    {
                        if (filterItem != null)
                        {
                            filterItems.Add(filterItem);
                            filterItem = null;
                        }
                        if (objectItem != null)
                        {
                            objectItem.Filters = filterItems.ToArray();
                            objectItems.Add(objectItem);
                            filterItems.Clear();
                        }

                        mode = ReadMode.Object;
                        objectItem = new ObjectItem();
                    }
                    else if (float.TryParse(number, out float filterNumber))
                    {
                        if (filterItem != null)
                        {
                            filterItems.Add(filterItem);
                            filterItem = null;
                        }

                        mode = ReadMode.Filter;
                    }
                }
                else if (_propertyRegex.IsMatch(line))
                {
                    Match match = _propertyRegex.Match(line);
                    string propertyName = match.Groups["propertyName"].Value;
                    string value = match.Groups["value"].Value;

                    if (propertyName == "_name")
                    {
                        filterItem = AbstractFilterItem.CreateFilterItem(value);
                    }
                    else
                    {
                        switch (mode)
                        {
                            case ReadMode.Exo:
                                result.SetProperty(propertyName, value);
                                break;
                            case ReadMode.Object:
                                objectItem.SetProperty(propertyName, value);
                                break;
                            case ReadMode.Filter:
                                filterItem.SetProperty(propertyName, value);
                                break;
                        }
                    }
                }
            }

            if (filterItem != null)
            {
                filterItems.Add(filterItem);
            }
            if (objectItem != null)
            {
                objectItem.Filters = filterItems.ToArray();
                objectItems.Add(objectItem);
            }

            result.ObjectItems = objectItems.ToArray();
            return result;
        }

        #endregion

        #region Field

        private static readonly Regex _objectNumberRegex = new(@"^\[(?<number>.+)\]$");

        private static readonly Regex _propertyRegex = new(@"^(?<propertyName>.+)=(?<value>.+)$");

        #endregion
    }

    internal enum ReadMode
    {
        Exo,
        Object,
        Filter
    }
}
