using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2
{
    public class Scene : NotificationObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VideoWidth { get; set; }
        public int VideoHeight { get; set; }
        public int VideoRate { get; set; }
        public int VideoScale { get; set; }
        public int AudioRate { get; set; }
        public int CursorFrame { get; set; }
        public int DisplayFrame { get; set; }
        public int DisplayLayer { get; set; }
        public int DisplayZoom { get; set; }
        public int DisplayOrder { get; set; }
        public int? DisplayCamera { get; set; }
        public ObjectItem[] ObjectItems { get; set; } = [];
    }
}
