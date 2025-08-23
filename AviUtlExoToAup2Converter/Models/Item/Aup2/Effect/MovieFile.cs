using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public class MovieFile : NotificationObject, IEffect
    {
        public string EffectName => "動画ファイル";
        public SpanF PlayPosition { get; set; }
        public Span PlayRange { get; set; }
        public float PlaySpeed { get; set; }
        public string FilePath { get; set; }
        public int Track { get; set; }
        public bool IsLoop { get; set; }
        public bool HaveAudio { get; set; }

        public IReadOnlyList<string> ToContentText()
        {
            return [
                $"再生位置={PlayPosition.Start:F3},{PlayPosition.End:F3},再生範囲,0",
                $"再生速度={PlaySpeed:F2}",
                $"ファイル={FilePath}",
                $"トラック={Track}",
                $"ループ再生={(IsLoop ? 1 : 0)}",
                $"音声付き={(HaveAudio ? 1 : 0)}",
            ];
        }
    }
}
