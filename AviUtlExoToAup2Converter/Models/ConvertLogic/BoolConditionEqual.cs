using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class BoolConditionEqual : IValue<bool>
    {
        [DataMember]
        public required IValue<bool> Operand1 { get; set; }

        [DataMember]
        public required IValue<bool> Operand2 { get; set; }

        public bool Invoke(Dictionary<string, object> proxy)
        {
            bool value1 = Operand1.Invoke(proxy);
            if (!value1) return false;

            bool value2 = Operand2.Invoke(proxy);

            return value1 && value2;
        }
    }
}
