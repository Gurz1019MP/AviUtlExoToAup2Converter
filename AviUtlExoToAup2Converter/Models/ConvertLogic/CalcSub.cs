using System.Numerics;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class CalcSub<T> : IValue<T> where T : INumber<T>
    {
        [DataMember]
        public required IValue<T> Operand1 { get; set; }

        [DataMember]
        public required IValue<T> Operand2 { get; set; }

        public T? Invoke(Dictionary<string, object> proxy)
        {
            T? value1 = Operand1.Invoke(proxy);
            T? value2 = Operand2.Invoke(proxy);
            if (value1 != null && value2 != null)
            {
                return value1 - value2;
            }
            else
            {
                return default;
            }
        }
    }
}
