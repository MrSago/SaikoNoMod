using UniverseLib.UI;
using SaikoNoMod.Properties;

namespace SaikoNoMod.UI
{
    public static class UIManager
    {
        internal static UIBase? UiBase { get; private set; }
        internal static MainPanel? Panel { get; private set; }
        public static bool Enabled
        {
            get => UiBase != null && UiBase.Enabled;
            set
            {
                if (UiBase == null || UiBase.Enabled == value)
                    return;

                UniversalUI.SetUIActive(BuildInfo.GUID, value);
            }
        }

        public static void Init()
        {
            UiBase = UniversalUI.RegisterUI(BuildInfo.GUID, null);
            Panel = new(UiBase);
        }
    }
}
