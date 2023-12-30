// #if ML
using MelonLoader;
using MelonLoader.Utils;

[assembly: MelonPlatformDomain(MelonPlatformDomainAttribute.CompatibleDomains.IL2CPP)]
[assembly: MelonInfo(typeof(SaikoNoMod.Loader.MelonLoader.SaikoNoModMelonMod),
    SaikoNoMod.Properties.BuildInfo.NAME, SaikoNoMod.Properties.BuildInfo.VERSION,
    SaikoNoMod.Properties.BuildInfo.AUTHOR, SaikoNoMod.Properties.BuildInfo.DOWNLOADLINK)]
[assembly: MelonOptionalDependencies("UniverseLib")]
[assembly: MelonGame("Habupain", "Saiko no sutoka")]
[assembly: MelonColor(255, 196, 21, 169)]
[assembly: MelonAuthorColor(255, 33, 164, 176)]

namespace SaikoNoMod.Loader.MelonLoader
{
    public class SaikoNoModMelonMod : MelonMod, ISaikoNoModLoader
    {
        public string SaikoNoModFolderDestination => MelonEnvironment.ModsDirectory;

        public string UnhollowedModulesFolder => Path.Combine(
            Path.GetDirectoryName(SaikoNoModFolderDestination) ?? "",
            Path.Combine("MelonLoader", "Il2CppAssemblies")
        );

        // public ConfigHandler ConfigHandler => _configHandler;
        // public MelonLoaderConfigHandler _configHandler;

        public event Action<object>? Update;
        public override void OnUpdate() =>
            Update?.Invoke(this);

        public event Action<int, string>? SceneWasLoaded;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) =>
            SceneWasLoaded?.Invoke(buildIndex, sceneName);

        public event Action<int, string>? SceneWasInitialized;
        public override void OnSceneWasInitialized(int buildIndex, string sceneName) =>
            SceneWasInitialized?.Invoke(buildIndex, sceneName);

        public Action<object> OnLogMessage => MelonLogger.Msg;
        public Action<object> OnLogWarning => MelonLogger.Warning;
        public Action<object> OnLogError => MelonLogger.Error;

        public override void OnLateInitializeMelon()
        {
            // _configHandler = new MelonLoaderConfigHandler();
            SaikoNoModCore.Init(this);
        }
    }
}
// #endif
