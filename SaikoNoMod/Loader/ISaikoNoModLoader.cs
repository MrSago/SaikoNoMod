namespace SaikoNoMod.Loader
{
    public interface ISaikoNoModLoader
    {
        string SaikoNoModFolderDestination { get; }
        string UnhollowedModulesFolder { get; }

        // ConfigHandler ConfigHandler { get; }

        event Action<object>? Update;

        Action<object> OnLogMessage { get; }
        Action<object> OnLogWarning { get; }
        Action<object> OnLogError { get; }
    }
}
