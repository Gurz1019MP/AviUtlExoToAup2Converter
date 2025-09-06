using AviUtlExoToAup2Converter.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Convert
{
    public interface IMapper
    {
        IAttribute Map(Dictionary<string, object> proxy);
    }
}
