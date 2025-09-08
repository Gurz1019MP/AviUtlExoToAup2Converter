using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    public interface IValue<T>
    {
        T? Invoke(Dictionary<string, object> proxy);
    }
}
