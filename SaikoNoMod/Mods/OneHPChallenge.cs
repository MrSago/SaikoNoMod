using Il2Cpp;
using SaikoNoMod.Utils;

namespace SaikoNoMod.Mods
{
    public static class OneHPChallenge
    {
        public static bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                if (value && _healthManager != null)
                    ApplyChallenge();
                SaikoNoModCore.Log($"[OneHPChallenge] One HP Challenge: {(value ? "Enabled" : "Disabled")}");
            }
        }
        private static bool _enabled = false;

        private static HealthManager? _healthManager;

        public static void Init()
        {
            SaikoNoModCore.Loader.SceneWasLoaded += OnSceneWasLoaded;
        }

        private static void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName != ObjectNames.MAIN_LEVEL_SCENE)
                return;

            _healthManager = UnityUtils.GetGameManager()?.healthManager;

            if (_enabled)
                ApplyChallenge();
        }

        private static void ApplyChallenge()
        {
            if (_healthManager == null)
            {
                SaikoNoModCore.Log("[OneHPChallenge] HealthManager is null");
                return;
            }

            _healthManager.Health = 1.0f;
            _healthManager.maximumHealth = 1.0f;

            _healthManager.lowHealthMode = false;
            _healthManager.lowHealthSettings = false;

            _healthManager.maxPainAmount = 0.0f;
            _healthManager.painStopTime = 0.0f;

            _healthManager.maxHealthCanTake = 0.0f;
            _healthManager.maxRegenerateHealth = 0.0f;
            _healthManager.regenerationSpeed = 0.0f;
        }
    }
}
