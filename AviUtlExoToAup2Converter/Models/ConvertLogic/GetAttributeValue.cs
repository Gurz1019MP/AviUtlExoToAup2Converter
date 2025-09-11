using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item;
using Livet;
using System.Reflection;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class GetAttributeValue<T> : ConvertLogicBase, IValue<T>, ICloneable
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

        private string? _From;

        [DataMember]
        public string? From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }

        public T? Invoke(Dictionary<string, object> proxy)
        {
            if (Reference == null) throw new InvalidOperationException("Referenceが設定されていません");
            if (From == null) throw new InvalidOperationException("Fromが設定されていません");

            object target = proxy[Reference];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty("Attributes");
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            return ((IAttribute[])objValue).GetValue<T>(From);
        }

        public object Clone()
        {
            return new GetAttributeValue<T>()
            {
                Reference = Reference,
                From = From
            };
        }
    }
}
