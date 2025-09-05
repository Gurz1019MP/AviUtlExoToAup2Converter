namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct FloatAttribute(string name, float value, string format) : IAttribute<float>
    {
        public string Name { get; private set; } = name;

        public string ValueString => Value.ToString(Format);

        public float Value { get; private set; } = value;

        public string Format { get; private set; } = format;
    }
}
