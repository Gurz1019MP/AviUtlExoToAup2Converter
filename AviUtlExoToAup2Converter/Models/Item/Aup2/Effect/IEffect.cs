namespace AviUtlExoToAup2Converter.Models.Item.Aup2.Effect
{
    public interface IEffect
    {
        string EffectName { get; }

        IReadOnlyList<string> ToContentText();
    }
}
