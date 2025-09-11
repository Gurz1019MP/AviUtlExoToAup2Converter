using AviUtlExoToAup2Converter.Models.DAO;
using Livet;
using System.Reflection;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class GetProperty<T> : ConvertLogicBase, IValue<T>, ICloneable
    {
        private string? _Reference;

        [DataMember]
        public string? Reference
        {
            get
            { return _Reference; }
            set
            { 
                if (_Reference == value)
                    return;
                _Reference = value;
                RaisePropertyChanged();
            }
        }

        private string? _Property;

        [DataMember]
        public string? Property
        {
            get
            { return _Property; }
            set
            { 
                if (_Property == value)
                    return;
                _Property = value;
                RaisePropertyChanged();
            }
        }

        public T? Invoke(Dictionary<string, object> proxy)
        {
            if (Reference == null) throw new InvalidOperationException("Referenceが設定されていません");
            if (Property == null) throw new InvalidOperationException("Propertyが設定されていません");

            object target = proxy[Reference];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty(Property);
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            return (T)objValue;
        }

        public object Clone()
        {
            return new GetProperty<T>()
            {
                Reference = Reference,
                Property = Property
            };
        }
    }
}
