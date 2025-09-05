namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct Vector3Attribute(string name, Vector3 value) : IAttribute<Vector3>
    {
        public string Name { get; private set; } = name;

        public string ValueString => $"X:{Value.X:F2}, Y:{Value.Y:F2}, Z:{Value.Z:F2}";

        public Vector3 Value { get; private set; } = value;
    }
}
