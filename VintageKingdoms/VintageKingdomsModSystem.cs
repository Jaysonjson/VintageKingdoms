using VintageKingdoms.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace VintageKingdoms
{
    public class VintageKingdomsModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            VKSystems.Common = api;
            VKSystems.Mod = Mod;
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            VKSystems.Server = api;
            Network.VKNetwork.RegisterServer();
            VKSystems.KingdomManager = KingdomManager.Load();
            KingdomEvents.EventKingdomCreated += KingdomEventsOnEventKingdomCreated;
        }

        private void KingdomEventsOnEventKingdomCreated(Common.Kingdom kingdom)
        {
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            VKSystems.Client = api;
            Network.VKNetwork.RegisterClient();
        }

    }
}
