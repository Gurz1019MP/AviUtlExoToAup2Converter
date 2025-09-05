namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct IntAttribute(string name, int value) : IAttribute
    {
        public string Name { get; private set; } = name;

        public string ValueString => Value.ToString();

        public int Value { get; private set; } = value;
    }
}
