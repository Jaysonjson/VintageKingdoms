using VintageKingdoms.Client;
using VintageKingdoms.Common;
using VintageKingdoms.Common.Items;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.Client.NoObf;
using Vintagestory.GameContent;

namespace VintageKingdoms
{
    public class VKModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            VKSystems.Common = api;
            VKSystems.Mod = Mod;
            VKSystems.Harmony.PatchAll();
            api.RegisterItemClass("VKItemNugget", typeof(VKItemNugget));
            api.RegisterItemClass("VKItemOre", typeof(VKItemOre));
            api.RegisterItemClass("ItemSugarCaneRoot", typeof(ItemSugarCaneRoot));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            VKSystems.Server = api;
            Network.VKNetwork.RegisterServer();
            VKSystems.KingdomManager = KingdomManager.Load();
            KingdomCommands.Register();
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            VKSystems.Client = api;
            Network.VKNetwork.RegisterClient();
            KingdomPlayerNameTag.Init();
        }

        public override void Dispose()
        {
            base.Dispose();
            VKSystems.Harmony?.UnpatchAll("vintagekingdoms");
        }
    }
}
