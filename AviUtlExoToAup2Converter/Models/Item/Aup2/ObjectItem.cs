using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class ObjectItem : NotificationObject
    {
        public int Layer { get; set; }
        public bool IsFocus { get; set; }
        public Span Frame { get; set; }
        public IEffect[] Effects { get; set; } = [];
    }
}
