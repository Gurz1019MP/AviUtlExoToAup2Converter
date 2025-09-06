using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class Variable
    {
        [DataMember]
        public required string Key { get; set; }

        [DataMember]
        public required IValue Value { get; set; }

        public dynamic Eval(Dictionary<string, object> proxy)
        {
            return ((dynamic)Value).Invoke(proxy);
        }
    }
}
