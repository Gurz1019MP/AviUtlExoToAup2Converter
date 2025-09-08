using AviUtlExoToAup2Converter.Models.Item;
using System.Reflection;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class GetAttributeValue<T> : IValue<T>
    {
        [DataMember]
        public string Reference {  get; set; } = string.Empty;

        [DataMember]
        public string From { get; set; } = string.Empty;

        public T? Invoke(Dictionary<string, object> proxy)
        {
            object target = proxy[Reference];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty("Attributes");
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            return ((IAttribute[])objValue).GetValue<T>(From);
        }
    }
}
