namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct StringAttribute(string name, string value) : IAttribute
    {
        public string Name { get; private set; } = name;

        public string ValueString => Value;

        public string Value { get; private set; } = value;
    }
}
