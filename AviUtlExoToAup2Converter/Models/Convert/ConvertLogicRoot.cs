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
                    Condition = new LogicCondition<string>()
                    {
                        Operand1 = new GetProperty<string>{ Reference = "filter", Property = "Name" },
                        Operand2 = new StringValue(){ Value = "動画ファイル" },
                        Operator = Operation.Equal
                    },
                    Mappers = [
                        new PlayPositionMapper(){
                            To = "再生位置",
                            Start = new FloatValue(){ Value = 0 },
                            End = new FloatValue(){ Value = 0 },
                            Range = new IntValue(){ Value = 0 },
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>{ Reference = "filter", From = "再生速度" },
                            To = "再生速度",
                            Format = "F2"
                        },
                        new StringMapper(){
                            From = new GetAttributeValue<string>{ Reference = "filter", From = "file" },
                            To = "ファイル"
                        },
                        new IntMapper(){
                            From = new GetAttributeValue<int>{ Reference = "filter", From = "ループ再生" },
                            To = "ループ再生"
                        },
                        new IntMapper(){
                            From = new IntValue{ Value = 1 },
                            To = "音声付き"
                        },
                    ]
                }
            ]
        };
    }
}
