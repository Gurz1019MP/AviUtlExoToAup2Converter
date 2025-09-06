using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class LogicCondition
    {
        [DataMember]
        public string Operand1 { get; set; } = string.Empty;

        [DataMember]
        public string Operand2 { get; set; } = string.Empty;

        [DataMember]
        public Operation Operator { get; set; } = Operation.None;

        public bool Judge(Dictionary<string, object> proxy)
        {
            if (Operator != Operation.Equal)
            {
                return proxy.Eval(Operand1) == proxy.Eval(Operand2);
            }
            else
            {
                return false;
            }
        }

        public enum Operation
        {
            None,
            Equal,
        }
    }
}
