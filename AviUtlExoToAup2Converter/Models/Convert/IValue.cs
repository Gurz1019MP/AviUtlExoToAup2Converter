using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    public interface IValue { }

    public interface IValue<T> : IValue
    {
        T? Invoke(Dictionary<string, object> proxy);
    }
}
