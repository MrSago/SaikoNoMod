using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;


[assembly: MelonInfo(typeof(SaikoNoMod.SaikoNoModCore), SaikoNoMod.Properties.BuildInfo.Name, SaikoNoMod.Properties.BuildInfo.Version,
    SaikoNoMod.Properties.BuildInfo.Author, SaikoNoMod.Properties.BuildInfo.DownloadLink)]
[assembly: MelonOptionalDependencies("UniverseLib")]
[assembly: MelonGame("Habupain", "Saiko no sutoka")]
[assembly: MelonColor(255, 33, 164, 176)]
[assembly: MelonAuthorColor(255, 196, 21, 169)]


[assembly: AssemblyTitle(SaikoNoMod.Properties.BuildInfo.Name)]
[assembly: AssemblyDescription(SaikoNoMod.Properties.BuildInfo.Description)]
[assembly: AssemblyProduct(SaikoNoMod.Properties.BuildInfo.Name)]
[assembly: AssemblyCompany(SaikoNoMod.Properties.BuildInfo.Company)]
[assembly: AssemblyCopyright("Created by " + SaikoNoMod.Properties.BuildInfo.Author)]
[assembly: AssemblyVersion(SaikoNoMod.Properties.BuildInfo.Version)]
[assembly: AssemblyFileVersion(SaikoNoMod.Properties.BuildInfo.Version)]


[assembly: ComVisible(false)]
[assembly: Guid("0e92b3a7-d20f-4a67-bafb-69bff8685139")]