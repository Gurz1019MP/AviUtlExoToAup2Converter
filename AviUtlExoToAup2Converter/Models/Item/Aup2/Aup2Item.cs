using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class Aup2Item : NotificationObject
    {
        public Scene[] Scenes { get; set; } = [];
    }
}
