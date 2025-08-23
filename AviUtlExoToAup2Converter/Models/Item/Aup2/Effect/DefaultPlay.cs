using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public class DefaultPlay : NotificationObject, IEffect
    {
        public string EffectName => "音声再生";
        public float Volume { get; set; }
        public float Pan { get; set; }

        public IReadOnlyList<string> ToContentText()
        {
            return [
                $"音量={Volume:F2}",
                $"左右={Pan:F2}",
            ];
        }
    }
}
