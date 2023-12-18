using Il2Cpp;
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
                    SaikoNoModCore.LogWarning($"Can't find GameObject {objectName}!");
                    return null;
                }
                SaikoNoModCore.Log($"GameObject {objectName} found!");
            }
            catch (Exception ex)
            {
                SaikoNoModCore.LogError(ex);
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
                    SaikoNoModCore.LogWarning(
                        $"Can't find {nameof(HFPS_GameManager)} " +
                        $"component of GameObject {ObjectNames.GAME_MANAGER}!"
                    );
                    return null;
                }
                SaikoNoModCore.Log($"GameManager of {nameof(HFPS_GameManager)} {ObjectNames.GAME_MANAGER} found!");
            }
            catch (Exception ex)
            {
                SaikoNoModCore.LogError(ex);
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
                    SaikoNoModCore.LogWarning(
                        $"Can't find {nameof(YandereController)} " +
                        $"component of GameObject {yandereObject?.name}!"
                    );
                    return null;
                }
                SaikoNoModCore.Log($"Controller {nameof(YandereController)} found!");
            }
            catch (Exception ex)
            {
                SaikoNoModCore.LogError(ex);
            }
            return controller;
        }

        public static void ChangeKeyBind(string keyDescription)
        {

        }
    }
}
