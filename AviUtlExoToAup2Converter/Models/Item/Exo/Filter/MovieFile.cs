using System.Collections.Generic;

namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public class MovieFile : AbstractFilterItem
    {
        #region Property

        public override string Name { get => "動画ファイル"; }
        public int Position { get; set; }
        public float Speed { get; set; }
        public byte Loop { get; set; }
        public byte Alpha { get; set; }
        public string File { get; set; }

        #endregion

        #region Method

        public override void SetProperty(string propertyName, string value)
        {
            if (propertyName == "再生位置")
            {
                Position = int.Parse(value);
            }
            else if (propertyName == "再生速度")
            {
                Speed = float.Parse(value);
            }
            else if (propertyName == "ループ再生")
            {
                Loop = byte.Parse(value);
            }
            else if (propertyName == "アルファチャンネルを読み込む")
            {
                Alpha = byte.Parse(value);
            }
            else if (propertyName == "file")
            {
                File = value;
            }
        }

        public override IReadOnlyList<string> ToContentText()
        {
            List<string> contents = new();

            contents.Add($"再生位置={Position}");
            contents.Add($"再生速度={Speed}");
            contents.Add($"ループ再生={Loop}");
            contents.Add($"アルファチャンネルを読み込む={Alpha}");
            contents.Add($"file={File}");

            return contents;
        }

        public override AbstractFilterItem Clone()
        {
            return new MovieFile()
            {
                Position = Position,
                Speed = Speed,
                Loop = Loop,
                Alpha = Alpha,
                File = File
            };
        }

        #endregion
    }
}
