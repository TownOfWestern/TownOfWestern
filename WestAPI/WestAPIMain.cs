using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace WestAPI;

[BepInPlugin(WestAPIInfo.Guid, WestAPIInfo.Name, WestAPIInfo.Version)]
[BepInProcess("Among Us.exe")]
public class WestAPIMain : BasePlugin
{
    Harmony harmony = new(WestAPIInfo.Guid);
    public const bool IsDebugMode = true;
    public override void Load()
    {
        harmony.PatchAll();
        RegisterModStamp();
    }
    static void RegisterModStamp()
    {
        SceneManager.add_sceneLoaded(
            (Action<Scene, LoadSceneMode>)
            (
                (scene, mode) =>
                {
                    if (scene.name == "MainMenu") ModManager.Instance.ShowModStamp();
                }
            )
        );
    }
}
public static class WestAPIInfo
{
    public const string Guid = "Blade.hvtXsvc.WestAPI";
    public const string Name = "WestAPI";
    public const string Version = "1.0.0";
}