
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Panels;
using UnityEngine.UI;
using UnityEngine;
using UniverseLib.Input;
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

        public static void InitUI()
        {
            UiBase = UniversalUI.RegisterUI(BuildInfo.GUID, null);
            Panel = new(UiBase);
        }
    }
}
