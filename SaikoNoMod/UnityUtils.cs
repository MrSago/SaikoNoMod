using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace SaikoNoMod
{
    public static class UnityUtils
    {
        public static GameObject? GetGameObject(string objectName)
        {
            GameObject? gameObject = null;
            try
            {
                gameObject = GameObject.Find(objectName);
                if (gameObject == null)
                {
                    MelonLogger.Error($"Can't find {nameof(GameObject)} {objectName}!");
                    return null;
                }
                MelonLogger.Msg($"GameObject {objectName} found!");
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
            return gameObject;
        }

        public static HFPS_GameManager? GetGameManager()
        {
            HFPS_GameManager? manager = null;
            try
            {
                manager = GameObject.Find(ObjectNames.GAME_MANAGER)?.GetComponent<HFPS_GameManager>();
                if (manager == null)
                {
                    MelonLogger.Error(
                        $"Can't find {nameof(HFPS_GameManager)} " +
                        $"component of {nameof(GameObject)} {ObjectNames.GAME_MANAGER}!"
                    );
                    return null;
                }
                MelonLogger.Msg($"GameManager {nameof(HFPS_GameManager)} found!");

            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
            return manager;
        }

        public static YandereController? GetYandereController(GameObject? yandereObject)
        {
            YandereController? controller = null;
            try
            {
                controller = yandereObject?.GetComponent<YandereController>();
                if (controller == null)
                {
                    MelonLogger.Error(
                        $"Can't find {nameof(YandereController)} " +
                        $"component of {nameof(GameObject)} {yandereObject?.name}!"
                    );
                    return null;
                }
                MelonLogger.Msg($"Controller {nameof(YandereController)} found!");
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
            return controller;
        }

        public static void ChangeKeyBind(string keyDescription)
        {

        }
    }
}