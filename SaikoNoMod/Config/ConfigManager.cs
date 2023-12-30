namespace SaikoNoMod.Config
{
    public static class ConfigManager
    {
        internal static readonly Dictionary<string, IConfigElement> ConfigElements = new();

        public static ConfigHandler Handler { get; private set; }

        public static ConfigElement<float> StartupDelayTime;
        public static ConfigElement<bool> DisableEventSystemOverride;
        public static ConfigElement<bool> ForceUnlockMouse;
        public static ConfigElement<bool> OneHPChallange;

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

            OneHPChallange = new("OneHPChallange",
                "One HP Challenge",
                false);
        }
    }
}