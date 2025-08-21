using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using Vintagestory.API.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VintageKingdoms.Network.Channel
{

    //Sends the entire KingdomManager class to the Client, should be used when a player joins
    public class KingdomManagerChannel : NetworkChannel<KingdomManager>
    {
        public override string Id()
        {
            return "kingdom_manager";
        }

        public override void ClientMessageHandler(IServerPlayer fromPlayer, KingdomManager packet)
        {
        }

        public override void ServerMessageHandler(KingdomManager packet)
        {
            VKSystems.KingdomManager = packet;
        }
    }
}
