using MelonLoader;
using MelonLoader.Utils;
using UniverseLib;
using UniverseLib.UI;
using UniverseLib.UI.Panels;

namespace SaikoNoMod.UI
{
    public class UILoader
    {
        public UIBase UiBase { get; private set; }
        public Panel PanelBase { get; private set; }
        public static void Log(object message) => MelonLogger.Msg(message);

        public UILoader()
        {
            Universe.Init(2.0f, null, null, new()
            {
                Disable_EventSystem_Override = false, // or null
                Force_Unlock_Mouse = false, // or null
                Unhollowed_Modules_Folder = Path.Combine(
                Path.GetDirectoryName(MelonEnvironment.ModsDirectory),
                Path.Combine("MelonLoader", "Il2CppAssemblies"))
            }
            );
            UiBase = UniversalUI.RegisterUI(GetHashCode().ToString(), Update);
            PanelBase = new(UiBase);
        }

        public void Update(){}
    }
}