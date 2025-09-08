using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    [DataContract]
    public class LogicItem
    {
        [DataMember]
        public string EffectName { get; set; } = string.Empty;

        [DataMember]
        public LogicCondition<string>? Condition { get; set; }

        [DataMember]
        public IMapper[] Mappers { get; set; } = [];
    }
}
