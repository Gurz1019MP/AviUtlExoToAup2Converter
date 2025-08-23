using System.Collections.Generic;

namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public class AudioFile : AbstractFilterItem
    {
        #region Property

        public override string Name { get => "音声ファイル"; }
        public float Position { get; set; }
        public float Speed { get; set; }
        public byte Loop { get; set; }
        public int Alignment { get; set; }
        public string File { get; set; }

        #endregion

        #region Method

        public override void SetProperty(string propertyName, string value)
        {
            if (propertyName == "再生位置")
            {
                Position = float.Parse(value);
            }
            else if (propertyName == "再生速度")
            {
                Speed = float.Parse(value);
            }
            else if (propertyName == "ループ再生")
            {
                Loop = byte.Parse(value);
            }
            else if (propertyName == "動画ファイルと連携")
            {
                Alignment = int.Parse(value);
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
            contents.Add($"動画ファイルと連携={Alignment}");
            contents.Add($"file={File}");

            return contents;
        }

        public override AbstractFilterItem Clone()
        {
            return new AudioFile()
            {
                Position = Position,
                Speed = Speed,
                Loop = Loop,
                Alignment = Alignment,
                File = File
            };
        }

        #endregion
    }
}
