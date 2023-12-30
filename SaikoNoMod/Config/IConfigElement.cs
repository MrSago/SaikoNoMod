namespace SaikoNoMod.Config
{
    public interface IConfigElement
    {
        string Name { get; }
        string Description { get; }

        object BoxedValue { get; set; }
        object DefaultValue { get; }

        Action? OnValueChangedNotify { get; set; }

        object GetLoaderConfigValue();

        void RevertToDefaultValue();
    }
}