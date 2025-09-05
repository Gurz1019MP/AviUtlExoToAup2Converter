namespace AviUtlExoToAup2Converter.Models.Item
{
    public interface IAttribute
    {
        string Name { get; }

        string ValueString { get; }
    }

    public interface IAttribute<T> : IAttribute
    {
        T Value { get; }
    }

    public static class IAttributeExtention
    {
        public static IAttribute Get(this IAttribute[] attributes, string name)
        {
            return attributes.First(a => a.Name == name);
        }

        public static T GetValue<T>(this IAttribute[] attributes, string name)
        {
            return ((IAttribute<T>)attributes.Get(name)).Value;
        }
    }
}
