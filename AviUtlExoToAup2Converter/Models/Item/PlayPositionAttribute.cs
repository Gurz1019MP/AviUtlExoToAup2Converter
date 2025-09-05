namespace AviUtlExoToAup2Converter.Models.Item
{
    public struct PlayPositionAttribute(string name, PlayPosition value) : IAttribute<PlayPosition>
    {
        public string Name { get; private set; } = name;

        public string ValueString => $"{Value.Start:F3},{Value.End:F3},再生範囲,{Value.Range}";

        public PlayPosition Value { get; private set; } = value;
    }
}
