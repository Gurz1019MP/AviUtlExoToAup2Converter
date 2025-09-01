namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public struct IntAttribute(string name, int value) : IAttribute
    {
        public string Name { get; private set; } = name;

        public string ValueString => Value.ToString();

        public int Value { get; private set; } = value;
    }
}
