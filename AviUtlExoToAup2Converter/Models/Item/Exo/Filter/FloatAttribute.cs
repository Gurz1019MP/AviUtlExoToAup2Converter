namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public struct FloatAttribute(string name, float value, string format) : IAttribute
    {
        public string Name { get; private set; } = name;

        public string ValueString => Value.ToString(Format);

        public float Value { get; private set; } = value;

        public string Format { get; private set; } = format;
    }
}
