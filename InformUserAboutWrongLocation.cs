using BepInEx;

namespace KayceeCardnamePatch
{
    [BepInPlugin("xyz.ardittristan.KayceeCardnamePatch", "KayceeCardnamePatch", "0.0.1")]
    internal class InformUserAboutWrongLocation : BaseUnityPlugin
    {
        // Token: 0x06000007 RID: 7 RVA: 0x000024E3 File Offset: 0x000006E3
        public void Awake()
        {
            base.Logger.LogError("This .dll should be in your patchers folder. Read the installation instructions and try again!");
        }
    }
}
