using SaikoNoMod.Properties;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(BuildInfo.NAME)]
[assembly: AssemblyDescription(BuildInfo.DESCRIPTION)]
[assembly: AssemblyProduct(BuildInfo.NAME)]
[assembly: AssemblyCompany(BuildInfo.COMPANY)]
[assembly: AssemblyCopyright("Created by " + BuildInfo.AUTHOR)]
[assembly: AssemblyVersion(BuildInfo.VERSION)]
[assembly: AssemblyFileVersion(BuildInfo.VERSION)]

[assembly: ComVisible(false)]
[assembly: Guid(BuildInfo.GUID)]
