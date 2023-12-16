using Il2Cpp;
using MelonLoader;
using UnityEngine;
using UniverseLib;
using UniverseLib.Input;

namespace SaikoNoMod
{
    public class SaikoNoModCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            _ui = new();
        }

        public override void OnUpdate()
        {
            if (InputManager.GetKeyDown(KeyCode.F1))
            {
                if (_ui != null)
                {
                    _ui.UiBase.Enabled = !_ui.UiBase.Enabled;
                }
            }
        }

        public override void OnLateUpdate()
        {

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case ObjectNames.MainMenuScene:
                    break;

                case ObjectNames.MainLevelScene:
                    _gameManager = UnityUtils.GetGameManager();
                    _controlFreak = UnityUtils.GetGameObject(ObjectNames.ControlFreak);
                    _nightmare = UnityUtils.GetGameObject(ObjectNames.NightmareObject);
                    _yandereController = UnityUtils.GetYandereController(_nightmare);
                    break;

                default:
                    break;
            }
        }

        private UI.UILoader? _ui = null;
        private HFPS_GameManager? _gameManager = null;
        private GameObject? _controlFreak = null;
        private GameObject? _nightmare = null;
        private YandereController? _yandereController = null;
    }
}
