using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    public interface IValue { }

    public interface IValue<T> : IValue
    {
        T? Invoke(Dictionary<string, object> proxy);
    }

    public static class IValueExtention
    {
        public static IValue<TargetType> ToType<BaseType, TargetType>(this IValue<BaseType> value)
        {
            if (value is GetAttributeValue<BaseType> getAttributeValue)
            {
                return getAttributeValue.ToType<BaseType, TargetType>();
            }
            else if (value is GetProperty<BaseType> getProperty)
            {
                return getProperty.ToType<BaseType, TargetType>();
            }
            else if (value is CalcSum<BaseType> calcSum)
            {
                return calcSum.ToType<BaseType, TargetType>();
            }
            else if (value is CalcSub<BaseType> calcSub)
            {
                return calcSub.ToType<BaseType, TargetType>();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public static ConditionEqual<TargetType> ToType<BaseType, TargetType>(this ConditionEqual<BaseType> org)
        {
            return new ConditionEqual<TargetType>()
            {
                Operand1 = org.Operand1?.ToType<BaseType, TargetType>(),
                Operand2 = org.Operand2?.ToType<BaseType, TargetType>(),
            };
        }

        public static GetAttributeValue<TargetType> ToType<BaseType, TargetType>(this GetAttributeValue<BaseType> org)
        {
            return new GetAttributeValue<TargetType>()
            {
                From = org.From,
                Reference = org.Reference,
            };
        }

        public static GetProperty<TargetType> ToType<BaseType, TargetType>(this GetProperty<BaseType> org)
        {
            return new GetProperty<TargetType>()
            {
                Property = org.Property,
                Reference = org.Reference,
            };
        }

        public static CalcSum<TargetType> ToType<BaseType, TargetType>(this CalcSum<BaseType> org)
        {
            return new CalcSum<TargetType>()
            {
                Operand1 = org.Operand1?.ToType<BaseType, TargetType>(),
                Operand2 = org.Operand2?.ToType<BaseType, TargetType>(),
            };
        }

        public static CalcSub<TargetType> ToType<BaseType, TargetType>(this CalcSub<BaseType> org)
        {
            return new CalcSub<TargetType>()
            {
                Operand1 = org.Operand1?.ToType<BaseType, TargetType>(),
                Operand2 = org.Operand2?.ToType<BaseType, TargetType>(),
            };
        }
    }
}
