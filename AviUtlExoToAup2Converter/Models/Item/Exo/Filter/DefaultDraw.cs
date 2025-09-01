namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public class DefaultDraw : AbstractFilterItem
    {
        #region Property

        public override string Name { get => "標準描画"; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Zoom { get; set; }
        public float Alpha { get; set; }
        public float Rotate { get; set; }
        public byte Blend { get; set; }

        #endregion

        #region Method

        public override void SetProperty(string propertyName, string value)
        {
            if (propertyName == "X")
            {
                X = float.Parse(value);
            }
            else if (propertyName == "Y")
            {
                Y = float.Parse(value);
            }
            else if (propertyName == "Z")
            {
                Z = float.Parse(value);
            }
            else if (propertyName == "拡大率")
            {
                Zoom = float.Parse(value);
            }
            else if (propertyName == "透明度")
            {
                Alpha = float.Parse(value);
            }
            else if (propertyName == "回転")
            {
                Rotate = float.Parse(value);
            }
            else if (propertyName == "blend")
            {
                Blend = byte.Parse(value);
            }
        }

        public override IReadOnlyList<string> ToContentText()
        {
            List<string> contents = new();

            contents.Add($"X={X}");
            contents.Add($"Y={Y}");
            contents.Add($"Z={Z}");
            contents.Add($"拡大率={Zoom}");
            contents.Add($"透明度={Alpha}");
            contents.Add($"回転={Rotate}");
            contents.Add($"blend={Blend}");

            return contents;
        }

        public override AbstractFilterItem Clone()
        {
            return new DefaultDraw()
            {
                X = X,
                Y = Y,
                Z = Z,
                Zoom = Zoom,
                Alpha = Alpha,
                Rotate = Rotate,
                Blend = Blend,
            };
        }

        #endregion
    }
}
