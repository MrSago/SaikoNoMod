using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SaikoNoMod.Patches
{
    [HarmonyPatch(typeof(Toggle), "OnPointerClick", new Type[] { typeof(PointerEventData) })]
    public static class NightmareUnlocker
    {
        public static void Postfix(Toggle __instance, PointerEventData __0)
        {
            try
            {
                if (__instance.name != ObjectNames.NIGHTMARE_UNLOCKER_TRIGGER) { return; }

                GameObject? playButtonObject = GameObject.Find(ObjectNames.PLAY_BUTTON);
                Button? playButton = playButtonObject?.GetComponent<Button>();
                if (playButton == null)
                {
                    SaikoNoModCore.LogWarning(
                        $"[{nameof(NightmareUnlocker)}] Can't find {nameof(Button)} " +
                        $"component of {nameof(GameObject)} {ObjectNames.PLAY_BUTTON}"
                    );
                    return;
                }
                playButton.interactable = true;

                GameObject? playTextObject = playButtonObject?.transform.GetChild(0)?.gameObject;
                Text? playText = playTextObject?.GetComponent<Text>();
                if (playText == null)
                {
                    SaikoNoModCore.LogWarning(
                        $"[{nameof(NightmareUnlocker)}] Can't get {nameof(Text)} " +
                        $"child(0) component of {nameof(GameObject)} {ObjectNames.PLAY_BUTTON}"
                    );
                    return;
                }
                playText.text = "Play";

                SaikoNoModCore.Log($"[{nameof(NightmareUnlocker)}] Play button for Nightmare mode successfully unlocked!");
            }
            catch (Exception ex)
            {
                SaikoNoModCore.LogError(ex);
            }
        }
    }
}