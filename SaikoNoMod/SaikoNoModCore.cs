using SaikoNoMod.Config;
using SaikoNoMod.Loader;
using SaikoNoMod.Mods;
using SaikoNoMod.Properties;
using SaikoNoMod.UI;
using SaikoNoMod.Utils;
using UnityEngine;
using UniverseLib;

namespace SaikoNoMod
{
    public static class SaikoNoModCore
    {
        public static ISaikoNoModLoader Loader { get; private set; } = null!;

        public static void Init(ISaikoNoModLoader loader)
        {
            if (Loader != null)
                throw new Exception($"{BuildInfo.NAME} is already initialized");

            Loader = loader;

            Log($"{BuildInfo.NAME} v{BuildInfo.VERSION} initializing...");

            ConfigManager.Init(Loader.ConfigHandler);

            Universe.Init(0.0f, LateInit, Log, new()
            {
                Disable_EventSystem_Override = ConfigManager.DisableEventSystemOverride.Value,
                Force_Unlock_Mouse = ConfigManager.ForceUnlockMouse.Value,
                Unhollowed_Modules_Folder = Loader.UnhollowedModulesFolder
            });

            Loader.Update += OnUpdate;
            Loader.SceneWasLoaded += OnSceneWasLoaded;
            Loader.SceneWasInitialized += OnSceneWasInitialized;

            OneHPChallenge.Init();
        }

        private static void LateInit()
        {
            Log("Loading UI...");

            UIManager.Init();

            Log($"{BuildInfo.NAME} v{BuildInfo.VERSION} initialized!");
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
                    Loader.OnLogMessage(log);
                    break;

                case LogType.Warning:
                    Loader.OnLogWarning(log);
                    break;

                case LogType.Error:
                case LogType.Exception:
                    Loader.OnLogError(log);
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}
