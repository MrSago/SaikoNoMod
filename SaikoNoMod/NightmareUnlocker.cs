using HarmonyLib;
using MelonLoader;

namespace SaikoNoMod
{
    [HarmonyPatch(typeof(UnityEngine.UI.Toggle), "OnPointerClick", new Type[] { typeof(UnityEngine.EventSystems.PointerEventData) })]
    public static class NightmareUnlocker
    {
        private const string TRIGGER_INSTANCE_NAME = "Exit (5)";
        private const string PLAY_BUTTON_NAME = "Practice (1)";

        public static void Postfix(UnityEngine.UI.Toggle __instance, UnityEngine.EventSystems.PointerEventData __0)
        {
            try
            {
                if (__instance.name != TRIGGER_INSTANCE_NAME) { return; }

                UnityEngine.GameObject? playButtonObject = UnityEngine.GameObject.Find(PLAY_BUTTON_NAME);
                UnityEngine.UI.Button? playButton = playButtonObject?.GetComponent<UnityEngine.UI.Button>();
                if (playButton == null)
                {
                    MelonLogger.Error($"[NightmareUnlocker] Can't get UnityEngine.UI.Button component of UnityEngine.GameObject ${PLAY_BUTTON_NAME}");
                    return;
                }
                playButton.interactable = true;

                UnityEngine.GameObject? playTextObject = playButtonObject?.transform.GetChild(0)?.gameObject;
                UnityEngine.UI.Text? playText = playTextObject?.GetComponent<UnityEngine.UI.Text>();
                if (playText == null)
                {
                    MelonLogger.Error($"[NightmareUnlocker] Can't get UnityEngine.UI.Text child(0) component of UnityEngine.GameObject ${PLAY_BUTTON_NAME}");
                    return;
                }
                playText.text = "Play";

                MelonLogger.Msg("[NightmareUnlocker] Play button for Nightmare mode successfully unlocked!");
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
        }
    }
}