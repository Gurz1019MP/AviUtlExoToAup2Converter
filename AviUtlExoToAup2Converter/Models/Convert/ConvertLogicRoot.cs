using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using System.Runtime.Serialization;

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
                    foreach(Variable entry in logic.LocalVars)
                    {
                        if (proxy.ContainsKey(entry.Key)) continue;
                        proxy.Add(entry.Key, entry.Eval(proxy));
                    }

                    if (!(logic.Condition.Invoke(proxy) == true)) continue;
                    effects.Add(new GeneralEffect(logic.EffectName, [.. logic.Mappers.Select(m => m.Map(proxy))]));
                    
                    foreach (Variable entry in logic.LocalVars)
                    {
                        if (!proxy.ContainsKey(entry.Key)) continue;
                        proxy.Remove(entry.Key);
                    }
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
                    Condition = new ConditionEqual<string>()
                    {
                        Operand1 = new GetProperty<string>{ Reference = "filter", Property = "Name" },
                        Operand2 = new StringValue(){ Value = "動画ファイル" },
                    },
                    Mappers = [
                        new PlayPositionMapper(){
                            To = "再生位置",
                            Start = new FrameToTime(){ 
                                Frame = new GetAttributeValue<int>(){ Reference = "filter", From = "再生位置" }
                            },
                            End = new CalcSum<float>(){ 
                                Operand1 = new FrameToTime(){
                                    Frame = new GetAttributeValue<int>() { Reference = "filter", From = "再生位置" }
                                },
                                Operand2 = new FrameToTime(){
                                    Frame = new CalcSub<int>(){
                                        Operand1 = new CalcSub<int>(){
                                            Operand1 = new GetAttributeValue<int>(){ Reference = "baseObjectItem", From = "end" },
                                            Operand2 = new GetAttributeValue<int>(){ Reference = "baseObjectItem", From = "start" }
                                        },
                                        Operand2 = new IntValue(){ Value = 1 }
                                    }
                                }
                            },
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
                },
                new LogicItem(){
                    EffectName = "映像再生",
                    Condition = new ConditionEqual<string>(){
                        Operand1 = new GetProperty<string>(){ Reference = "filter", Property = "Name" },
                        Operand2 = new StringValue(){ Value = "標準描画" },
                    },
                    Mappers = [
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "X" },
                            To = "X",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "Y" },
                            To = "Y",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "Z" },
                            To = "Z",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "中心X",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "中心Y",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "中心Z",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "X軸回転",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "Y軸回転",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "回転" },
                            To = "Z軸回転",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "拡大率" },
                            To = "拡大率",
                            Format = "F3"
                        },
                        new FloatMapper(){
                            From = new FloatValue(){ Value = 0 },
                            To = "縦横比",
                            Format = "F3"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "透明度" },
                            To = "透明度",
                            Format = "F2"
                        },
                        new StringMapper(){
                            From = new BlendModeValue(){ Value = new GetAttributeValue<int>(){ Reference = "filter", From = "blend" } },
                            To = "合成モード"
                        }
                    ]
                },
                new LogicItem(){
                    EffectName = "動画ファイル",
                    LocalVars = [
                        new Variable(){ Key = "alimentMovieFilter", Value = new FindFirstFilterByName(){ Name = "動画ファイル" } }
                    ],
                    Condition = new BoolConditionEqual(){
                        Operand1 = new ConditionEqual<string>(){
                            Operand1 = new GetProperty<string>(){ Reference = "filter", Property = "Name" },
                            Operand2 = new StringValue(){ Value = "音声ファイル" }
                        },
                        Operand2 = new ConditionEqual<int>(){
                            Operand1 = new GetAttributeValue<int>(){ Reference = "filter", From = "動画ファイルと連携" },
                            Operand2 = new IntValue(){ Value = 1 }
                        }
                    },
                    Mappers = [
                        new PlayPositionMapper(){
                            Start = new GetAttributeValue<float>(){ Reference = "filter", From = "再生位置" },
                            End = new CalcSum<float>(){
                                Operand1 = new GetAttributeValue<float>(){ Reference = "filter", From = "再生位置" },
                                Operand2 = new FrameToTime(){
                                    Frame = new CalcSub<int>(){
                                        Operand1 = new CalcSub<int>(){
                                            Operand1 = new GetAttributeValue<int>(){ Reference = "baseObjectItem", From = "end" },
                                            Operand2 = new GetAttributeValue<int>(){ Reference = "baseObjectItem", From = "start" }
                                        },
                                        Operand2 = new IntValue(){ Value = 1 }
                                    }
                                }
                            },
                            Range = new IntValue(){ Value = 0 }
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "再生速度" },
                            To = "再生速度",
                            Format = "F2"
                        },
                        new StringMapper(){
                            From = new GetAttributeValue<string>(){ Reference = "alimentMovieFilter", From = "file" },
                            To = "ファイル"
                        },
                        new IntMapper(){
                            From = new IntValue(){ Value = 0 },
                            To = "トラック"
                        },
                        new IntMapper(){
                            From = new GetAttributeValue<int>(){ Reference = "filter", From = "ループ再生" },
                            To = "ループ再生"
                        },
                        new IntMapper(){
                            From = new IntValue(){ Value = 1 },
                            To = "音声付き"
                        },
                    ]
                },
                new LogicItem(){
                    EffectName = "音声再生",
                    Condition = new ConditionEqual<string>(){
                        Operand1 = new GetProperty<string>(){ Reference = "filter", Property = "Name" },
                        Operand2 = new StringValue(){ Value = "標準再生" }
                    },
                    Mappers = [
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "音量" },
                            To = "音量",
                            Format = "F2"
                        },
                        new FloatMapper(){
                            From = new GetAttributeValue<float>(){ Reference = "filter", From = "左右" },
                            To = "左右",
                            Format = "F2"
                        },
                    ]
                }
            ]
        };
    }
}
