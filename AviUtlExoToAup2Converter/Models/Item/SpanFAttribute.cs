namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct SpanFAttribute(string name, SpanF value, string format) : IAttribute<SpanF>
    {
        public string Name { get; private set; } = name;

        public string ValueString => $"{Value.Start.ToString(Format)},{Value.End.ToString(Format)}";

        public SpanF Value { get; private set; } = value;

        public string Format { get; private set; } = format;

    }
}
