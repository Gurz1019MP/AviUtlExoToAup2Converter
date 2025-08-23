using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public class DefaultDraw : NotificationObject, IEffect
    {
        public string EffectName => "標準描画";
        public Vector3 Position { get; set; }
        public Vector3 Center { get; set; }
        public Vector3 Rotate { get; set; }
        public float Zoom { get; set; }
        public float Aspect { get; set; }
        public float Alpha { get; set; }
        public BlendMode BlendMode { get; set; }

        public IReadOnlyList<string> ToContentText()
        {
            return [
                $"X={Position.X:F2}",
                $"Y={Position.Y:F2}",
                $"Z={Position.Z:F2}",
                $"中心X={Center.X:F2}",
                $"中心Y={Center.Y:F2}",
                $"中心Z={Center.Z:F2}",
                $"X軸回転={Rotate.X:F2}",
                $"Y軸回転={Rotate.Y:F2}",
                $"Z軸回転={Rotate.Z:F2}",
                $"拡大率={Zoom:F3}",
                $"縦横比={Aspect:F3}",
                $"透明度={Alpha:F2}",
                $"合成モード={BlendMode}",
            ];
        }
    }
}
