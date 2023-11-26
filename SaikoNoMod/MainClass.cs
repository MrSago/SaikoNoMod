using MelonLoader;

namespace SaikoNoMod
{
    public class MainClass : MelonMod
    {
        private const string MAIN_MENU_SCENE_NAME = "MainMenu";
        private const string MAIN_LEVEL_SCENE_NAME = "LevelNew";
        private const string GAME_MANAGER_NAME = "GAMEMANAGER";
        private Il2Cpp.HFPS_GameManager? _gameManager;

        public override void OnUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case MAIN_MENU_SCENE_NAME:
                    break;

                case MAIN_LEVEL_SCENE_NAME:
                    GetGameManager();
                    break;

                default:
                    break;
            }
        }

        private void GetGameManager()
        {
            try
            {
                _gameManager = UnityEngine.GameObject.Find(GAME_MANAGER_NAME)?.GetComponent<Il2Cpp.HFPS_GameManager>();
                if (_gameManager == null)
                {
                    MelonLogger.Error($"Can't get ${nameof(Il2Cpp.HFPS_GameManager)} component of UnityEngine.GameObject ${GAME_MANAGER_NAME}!");
                    return;
                }
                MelonLogger.Msg("GameManager found!");
            }
            catch (Exception ex)
            {
                MelonLogger.Error(ex);
            }
        }
    }
}