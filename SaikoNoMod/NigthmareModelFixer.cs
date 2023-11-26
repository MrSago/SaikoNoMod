using HarmonyLib;
using MelonLoader;

namespace SaikoNoMod
{
    [HarmonyPatch(typeof(UnityEngine.UI.Toggle), "OnPointerClick", new Type[] { typeof(UnityEngine.EventSystems.PointerEventData) })]
    public static class NigthmareModelFixer
    {
        private const string TRIGGER_INSTANCE_NAME = "Exit (5)";
        private const string NIGHTMARE_MODEL_NAME = "nightmare";

        public static void Prefix(UnityEngine.UI.Toggle __instance, UnityEngine.EventSystems.PointerEventData __0)
        {

        }

        public static void Postfix(UnityEngine.UI.Toggle __instance, UnityEngine.EventSystems.PointerEventData __0)
        {
            try
            {
                if (__instance.name != TRIGGER_INSTANCE_NAME) { return; }

                UnityEngine.GameObject? nightmareModel = UnityEngine.GameObject.Find(NIGHTMARE_MODEL_NAME);
                if (nightmareModel == null)
                {
                    MelonLogger.Error($"[NightmareModelFixer] Can't find ${NIGHTMARE_MODEL_NAME} UnityEngine.GameObject");
                    return;
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
        }
    }
}