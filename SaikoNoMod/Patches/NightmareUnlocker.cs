using HarmonyLib;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SaikoNoMod.Mods
{
    [HarmonyPatch(typeof(Toggle), "OnPointerClick", new Type[] { typeof(PointerEventData) })]
    public static class NightmareUnlocker
    {
        public static void Postfix(Toggle __instance, PointerEventData __0)
        {
            try
            {
                if (__instance.name != ObjectNames.NightmareUnlockerTrigger) { return; }

                GameObject? playButtonObject = GameObject.Find(ObjectNames.PlayButton);
                Button? playButton = playButtonObject?.GetComponent<Button>();
                if (playButton == null)
                {
                    MelonLogger.Error($"[NightmareUnlocker] Can't get UnityEngine.UI.Button component of UnityEngine.GameObject ${ObjectNames.PlayButton}");
                    return;
                }
                playButton.interactable = true;

                GameObject? playTextObject = playButtonObject?.transform.GetChild(0)?.gameObject;
                Text? playText = playTextObject?.GetComponent<Text>();
                if (playText == null)
                {
                    MelonLogger.Error($"[NightmareUnlocker] Can't get UnityEngine.UI.Text child(0) component of UnityEngine.GameObject ${ObjectNames.PlayButton}");
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