// #if ML
using System;
using System.IO;
using MelonLoader;
using MelonLoader.Utils;
using SaikoNoMod.Loader;

[assembly: MelonPlatformDomain(MelonPlatformDomainAttribute.CompatibleDomains.IL2CPP)]
[assembly: MelonInfo(typeof(SaikoNoMod.Loader.MelonLoader.SaikoNoModMelonMod),
    SaikoNoMod.Properties.BuildInfo.NAME, SaikoNoMod.Properties.BuildInfo.VERSION,
    SaikoNoMod.Properties.BuildInfo.AUTHOR, SaikoNoMod.Properties.BuildInfo.DOWNLOADLINK)]
[assembly: MelonOptionalDependencies("UniverseLib")]
[assembly: MelonGame("Habupain", "Saiko no sutoka")]
[assembly: MelonColor(255, 33, 164, 176)]
[assembly: MelonAuthorColor(255, 196, 21, 169)]

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
        // public event EventHandler Kekis {
        //     add => MelonHandler.OnUpdate += value;
        //     remove => MelonHandler.OnUpdate -= value;
        // }

        public event Action<object>? Update;

        public override void OnUpdate()
        {
            Update?.Invoke(this);
        }

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