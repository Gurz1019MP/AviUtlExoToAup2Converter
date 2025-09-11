using AviUtlExoToAup2Converter.Models.ConvertLogic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace AviUtlExoToAup2Converter.Models.DAO
{
    public class XmlAccessObject
    {
        public static void Serialize(ConvertLogicRoot obj, string path)
        {
            DataContractSerializer serializer = new(typeof(ConvertLogicRoot), KNOWNTYPELIST);
            using var stream = new FileStream(path, FileMode.Truncate);
            using var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true });
            serializer.WriteObject(writer, obj);
        }

        public static ConvertLogicRoot? Deserialize(string path)
        {
            DataContractSerializer serializer = new(typeof(ConvertLogicRoot), KNOWNTYPELIST);
            using var stream = new FileStream(path, FileMode.Open);
            return serializer.ReadObject(stream) as ConvertLogicRoot;
        }

        public readonly static Type[] KNOWNTYPELIST = [
            typeof(BlendModeValue),
            typeof(BoolConditionEqual),
            typeof(CalcSub<int>),
            typeof(CalcSub<float>),
            typeof(CalcSub<Empty>),
            typeof(CalcSum<int>),
            typeof(CalcSum<float>),
            typeof(CalcSum<Empty>),
            typeof(ConditionEqual<string>),
            typeof(ConditionEqual<int>),
            typeof(ConditionEqual<float>),
            typeof(ConditionEqual<Empty>),
            typeof(FindFirstFilterByName),
            typeof(FloatMapper),
            typeof(FloatValue),
            typeof(FrameToTime),
            typeof(GetAttributeValue<string>),
            typeof(GetAttributeValue<int>),
            typeof(GetAttributeValue<float>),
            typeof(GetAttributeValue<Empty>),
            typeof(GetProperty<string>),
            typeof(GetProperty<int>),
            typeof(GetProperty<float>),
            typeof(GetProperty<Empty>),
            typeof(IntMapper),
            typeof(IntValue),
            typeof(PlayPositionMapper),
            typeof(StringMapper),
            typeof(StringValue),
            typeof(Variable),
        ];
    }
}
