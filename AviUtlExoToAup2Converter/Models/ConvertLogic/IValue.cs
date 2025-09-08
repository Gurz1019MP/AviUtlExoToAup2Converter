using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    public interface IValue { }

    public interface IValue<T> : IValue
    {
        T? Invoke(Dictionary<string, object> proxy);
    }
}
