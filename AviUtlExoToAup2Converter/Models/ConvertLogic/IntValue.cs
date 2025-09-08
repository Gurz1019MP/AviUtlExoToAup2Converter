using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class IntValue : IValue<int>
    {
        [DataMember]
        public int Value { get; set; }

        public int Invoke(Dictionary<string, object> proxy)
        {
            return Value;
        }
    }
}
