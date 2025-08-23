using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public interface IEffect
    {
        string EffectName { get; }

        IReadOnlyList<string> ToContentText();
    }
}
