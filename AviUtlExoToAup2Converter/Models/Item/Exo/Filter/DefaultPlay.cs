namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public class DefaultPlay : AbstractFilterItem
    {
        #region Property

        public override string Name { get => "標準再生"; }
        public float Volume { get; set; }
        public float Pan { get; set; }

        #endregion

        #region Method

        public override void SetProperty(string propertyName, string value)
        {
            if (propertyName == "音量")
            {
                Volume = float.Parse(value);
            }
            else if (propertyName == "左右")
            {
                Pan = float.Parse(value);
            }
        }

        public override IReadOnlyList<string> ToContentText()
        {
            List<string> contents = new();

            contents.Add($"音量={Volume}");
            contents.Add($"左右={Pan}");

            return contents;
        }

        public override AbstractFilterItem Clone()
        {
            return new DefaultPlay()
            {
                Volume = Volume,
                Pan = Pan
            };
        }

        #endregion
    }
}
