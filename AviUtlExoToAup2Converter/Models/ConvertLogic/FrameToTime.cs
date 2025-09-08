using AviUtlExoToAup2Converter.Models.Item;
using System.Reflection;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class FrameToTime : IValue<float>
    {
        [DataMember]
        public required IValue<int> Frame {  get; set; }

        public float Invoke(Dictionary<string, object> proxy)
        {
            object target = proxy["baseItem"];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty("Attributes");
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            int rate = ((IAttribute[])objValue).GetValue<int>("rate");
            int scale = ((IAttribute[])objValue).GetValue<int>("scale");
            float frameRate = rate / scale;
            return Frame.Invoke(proxy) / frameRate;
        }
    }
}
