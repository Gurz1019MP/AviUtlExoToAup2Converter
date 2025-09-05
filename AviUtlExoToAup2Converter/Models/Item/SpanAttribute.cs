namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct SpanAttribute(string name, Span value) : IAttribute<Span>
    {
        public string Name { get; private set; } = name;

        public string ValueString => $"{Value.Start},{Value.End}";

        public Span Value { get; private set; } = value;
    }
}
