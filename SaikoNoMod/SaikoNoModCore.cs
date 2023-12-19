using SaikoNoMod.Loader;
using SaikoNoMod.Properties;
using SaikoNoMod.UI;
using UniverseLib;
using UnityEngine;

namespace SaikoNoMod
{
    public static class SaikoNoModCore
    {
        public static ISaikoNoModLoader? Loader { get; private set; }

        public static void Init(ISaikoNoModLoader loader)
        {
            if (Loader != null)
                throw new Exception($"{BuildInfo.NAME} is already initialized");

            Loader = loader;

            Log($"{BuildInfo.NAME} v{BuildInfo.VERSION} initializing...");

            // Directory.CreateDirectory(ExplorerFolder);
            // ConfigManager.Init(Loader.ConfigHandler);

            Universe.Init(0.0f, LateInit, Log, new()
            {
                Disable_EventSystem_Override = false,
                Force_Unlock_Mouse = true,
                Unhollowed_Modules_Folder = Loader.UnhollowedModulesFolder
            });

            Loader.Update += OnUpdate;
            Loader.SceneWasLoaded += OnSceneWasLoaded;
            Loader.SceneWasInitialized += OnSceneWasInitialized;
        }

        private static void LateInit()
        {
            UIManager.InitUI();
        }

        private static void OnUpdate(object sender)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (UIManager.UiBase != null)
                {
                    UIManager.UiBase.Enabled = !UIManager.UiBase.Enabled;
                }
            }
        }

        private static void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case ObjectNames.MAIN_MENU_SCENE:
                    break;

                case ObjectNames.MAIN_LEVEL_SCENE:
                    // _gameManager = UnityUtils.GetGameManager();
                    // _controlFreak = UnityUtils.GetGameObject(ObjectNames.ControlFreak);
                    // _nightmare = UnityUtils.GetGameObject(ObjectNames.NightmareObject);
                    // _yandereController = UnityUtils.GetYandereController(_nightmare);
                    break;

                default:
                    break;
            }
        }

        private static void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case ObjectNames.MAIN_MENU_SCENE:
                    LocalizedMenuHandler.Init();
                    break;

                case ObjectNames.MAIN_LEVEL_SCENE:
                    break;

                default:
                    break;
            }
        }

        #region LOGGING

        public static void Log(object message)
            => Log(message, LogType.Log);

        public static void LogWarning(object message)
            => Log(message, LogType.Warning);

        public static void LogError(object message)
            => Log(message, LogType.Error);

        private static void Log(object message, LogType logType)
        {
            string log = message?.ToString() ?? "";

            switch (logType)
            {
                case LogType.Log:
                case LogType.Assert:
                    Loader?.OnLogMessage(log);
                    break;

                case LogType.Warning:
                    Loader?.OnLogWarning(log);
                    break;

                case LogType.Error:
                case LogType.Exception:
                    Loader?.OnLogError(log);
                    break;

                default:
                    break;
            }
        }

        #endregion


        // private UI.UILoader? _ui = null;
        // private HFPS_GameManager? _gameManager = null;
        // private GameObject? _controlFreak = null;
        // private GameObject? _nightmare = null;
        // private YandereController? _yandereController = null;
    }
}
