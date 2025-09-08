using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class LogicCondition<T>
    {
        [DataMember]
        public IValue<T> Operand1 { get; set; }

        [DataMember]
        public IValue<T> Operand2 { get; set; }

        [DataMember]
        public Operation Operator { get; set; } = Operation.None;

        public bool Judge(Dictionary<string, object> proxy)
        {
            T? value1 = Operand1.Invoke(proxy);
            T? value2 = Operand2.Invoke(proxy);
            if (Operator != Operation.Equal)
            {
                if (value1 != null && value2 != null)
                {
                    return value1.Equals(value2);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public enum Operation
    {
        None,
        Equal,
    }
}
