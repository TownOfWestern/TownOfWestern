using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using WestAPI;

namespace TownOfWestern;

[BepInPlugin("Blade.hvtXsvc.TownOfWestern", "TownOfWestern", "1.0.0")]
[BepInDependency(WestAPIInfo.Guid)]
[BepInProcess("Among Us.exe")]
public class TownOfWesternPlugin : BasePlugin
{
    public Harmony Harmony { get; } = new("Blade.hvtXsvc.TownOfWestern");

    public override void Load()
    {
        Log.LogInfo($"TownOfWestern loaded");
        Harmony.PatchAll();
    }
}
