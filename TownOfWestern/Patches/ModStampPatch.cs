namespace TownOfWestern.Patches;

[HarmonyPatch(typeof(ModManager), nameof(ModManager.ShowModStamp))]
public static class ModStampPatch
{
    public static void Postfix()
    {
        Dispatcher.Instance.Enqueue(() =>
        {
            var modStamp = GameObject.Find("ModStamp");
            if (modStamp == null)
            {
                return;
            }
            modStamp.transform.localScale = Vector3.one * 0.06f;
            var sr = modStamp.GetComponent<SpriteRenderer>();
            sr?.sprite = WestAPIAseets.LoadSpriteFromResource("Light.Resources.ModStamp.png");
        });
    }
}