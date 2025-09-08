using System.Reflection;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class GetProperty<T> : IValue<T>
    {
        [DataMember]
        public string Reference { get; set; } = string.Empty;

        [DataMember]
        public string Property { get; set; } = string.Empty;

        public T? Invoke(Dictionary<string, object> proxy)
        {
            object target = proxy[Reference];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty(Property);
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            return (T)objValue;
        }
    }
}
