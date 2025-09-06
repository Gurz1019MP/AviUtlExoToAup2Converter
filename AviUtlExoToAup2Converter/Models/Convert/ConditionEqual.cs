using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class ConditionEqual<T> : IValue<bool>
    {
        [DataMember]
        public required IValue<T> Operand1 { get; set; }

        [DataMember]
        public required IValue<T> Operand2 { get; set; }

        public bool Invoke(Dictionary<string, object> proxy)
        {
            T? value1 = Operand1.Invoke(proxy);
            T? value2 = Operand2.Invoke(proxy);
            if (value1 != null && value2 != null)
            {
                return value1.Equals(value2);
            }
            else
            {
                return false;
            }
        }
    }
}
