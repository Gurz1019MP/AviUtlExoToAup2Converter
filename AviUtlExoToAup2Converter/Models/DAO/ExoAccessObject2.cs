using AviUtlExoToAup2Converter.Models.Item.Exo;
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AviUtlExoToAup2Converter.Models.DAO
{
    internal static class ExoAccessObject2
    {
        #region Method

        public static ExoItem2? Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            ExoItem2 result = new();
            List<ObjectItem2> objectItems = [];
            ObjectItem2? objectItem = null;
            List<GeneralFilter> filterItems = [];
            GeneralFilter? filterItem = null;
            List<IAttribute> attributes = [];
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
                        if (attributes != null)
                        {
                            if (filterItem != null)
                            {
                                filterItem.Attributes = attributes.ToArray();
                            }
                            else
                            {
                                result.Attributes = attributes.ToArray();
                            }
                            attributes.Clear();
                        }

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
                        objectItem = new ObjectItem2();
                    }
                    else if (float.TryParse(number, out float filterNumber))
                    {
                        if (attributes != null)
                        {
                            if (filterItem != null)
                            {
                                filterItem.Attributes = attributes.ToArray();
                            }
                            else if (objectItem != null)
                            {
                                objectItem.Attributes = attributes.ToArray();
                            }
                            attributes.Clear();
                        }

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
                        filterItem = new GeneralFilter(value, []);
                    }
                    else
                    {
                        if (int.TryParse(value, out int intValue))
                        {
                            attributes.Add(new IntAttribute(propertyName, intValue));
                        }
                        else if (float.TryParse(value, out float floatValue))
                        {
                            string[] parts = value.Split('.');
                            attributes.Add(new FloatAttribute(propertyName, floatValue, $"F{parts[1].Length}"));
                        }
                        else
                        {
                            attributes.Add(new StringAttribute(propertyName, value));
                        }
                    }
                }
            }

            if (filterItem != null)
            {
                if (attributes != null)
                {
                    filterItem.Attributes = attributes.ToArray();
                    attributes.Clear();
                }
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
}
