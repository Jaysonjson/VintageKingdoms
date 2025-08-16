using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace VintageKingdoms.Network
{
    public class KingdomNetwork
    {
        public static IClientNetworkChannel ClientKingdom { get; private set; } = null;
        public static IServerNetworkChannel ServerKingdom { get; private set; } = null;

        public static void RegisterClient()
        {
            ClientKingdom = VKSystems.Client.Network.RegisterChannel("kingdom").RegisterMessageType(typeof(KingdomManager)).SetMessageHandler<KingdomManager>(new NetworkServerMessageHandler<KingdomManager>(onKingdomServerData));
        }

        public static void RegisterServer()
        {
            ServerKingdom = VKSystems.Server.Network.RegisterChannel("kingdom").RegisterMessageType(typeof(KingdomManager));
        }


        private static void onKingdomServerData(KingdomManager data)
        {
            VKSystems.KingdomManager = data;
            foreach (var (key, entity) in VKSystems.Client.World.LoadedEntities)
            {
                if (entity is EntityPlayer player)
                {
                    if (player.IsInsideKingdom())
                    {
                        string name = player.GetKingdom().Name;
                        if (!player.GetName().Contains(name))
                        {
                            player.GetBehavior<EntityBehaviorNameTag>()?.SetName(player.GetName() + "\n" + name);
                        }
                    }
                }
            }
        }
    }
}
