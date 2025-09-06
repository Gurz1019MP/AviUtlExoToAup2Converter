using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class ConvertLogicRoot
    {
        [DataMember]
        public LogicItem[] LogicItems { get; set; } = [];

        public GeneralEffect[] FiltersToEffects(ExoItem baseItem, Item.Exo.ObjectItem baseObjectItem)
        {
            List<GeneralEffect> effects = [];
            Dictionary<string, object> proxy = new Dictionary<string, object>()
            {
                { "baseItem", baseItem },
                { "baseObjectItem", baseObjectItem }
            };

            foreach(GeneralFilter filter in baseObjectItem.Filters)
            {
                if (proxy.ContainsKey("filter"))
                {
                    proxy["filter"] = filter;
                }
                else
                {
                    proxy.Add("filter", filter);
                }

                foreach (LogicItem logic in LogicItems)
                {
                    if (!(logic.Condition?.Judge(proxy) == true)) continue;
                    effects.Add(new GeneralEffect(logic.EffectName, [.. logic.Mappers.Select(m => m.Map(proxy))]));
                }
            }

            return [.. effects];
        }

        public readonly static ConvertLogicRoot DevLogic = new()
        {
            LogicItems = [
                new LogicItem()
                {
                    EffectName = "動画ファイル",
                    Condition = new LogicCondition()
                    {
                        Operand1 = "<root><var name='filter'>Name</var></root>",
                        Operand2 = "<root>動画ファイル</root>",
                        Operator = LogicCondition.Operation.Equal
                    },
                    Mappers = [
                        new FloatMapper(){
                            From = "<root proxy='filter'>再生速度</root>",
                            To = "再生速度",
                            Format = "F2"
                        },
                        new StringMapper(){
                            From = "<root proxy='filter'>file</root>",
                            To = "ファイル"
                        },
                        new IntMapper(){
                            From = "<root proxy='filter'>ループ再生</root>",
                            To = "ループ再生"
                        },
                        new IntMapper(){
                            From = "<root>1</root>",
                            To = "音声付き"
                        },
                    ]
                }
            ]
        };
    }
}
