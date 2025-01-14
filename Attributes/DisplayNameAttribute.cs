namespace RetailCorrector.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisplayNameAttribute(string displayName) : Attribute
    {
        public string Name { get; } = displayName;
    }
}
