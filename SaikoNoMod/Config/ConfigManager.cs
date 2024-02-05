namespace SaikoNoMod.Config
{
    public static class ConfigManager
    {
        internal static readonly Dictionary<string, IConfigElement> ConfigElements = new();

        public static ConfigHandler Handler { get; private set; } = null!;

        public static ConfigElement<float> StartupDelayTime { get; private set; } = null!;
        public static ConfigElement<bool> DisableEventSystemOverride { get; private set; } = null!;
        public static ConfigElement<bool> ForceUnlockMouse { get; private set; } = null!;
        public static ConfigElement<bool> OneHPChallange { get; private set; } = null!;

        public static void Init(ConfigHandler handler)
        {
            Handler = handler;
            Handler.Init();

            CreateConfigElements();

            Handler.LoadConfig();
        }

        internal static void RegisterConfigElement<T>(ConfigElement<T> element)
        {
            Handler.RegisterConfigElement(element);
            ConfigElements.Add(element.Name, element);
        }

        private static void CreateConfigElements()
        {
            StartupDelayTime = new("StartupDelayTime",
                "Startup delay time",
                0.0f);

            DisableEventSystemOverride = new("DisableEventSystemOverride",
                "Disable event system override",
                false);

            ForceUnlockMouse = new("ForceUnlockMouse",
                "Force unlock mouse",
                true);
        }
    }
}