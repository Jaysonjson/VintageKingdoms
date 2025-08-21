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
    //Sends a single Kingdom to the Client
    public class KingdomChannel : NetworkChannel<Kingdom>
    {
        public override string Id()
        {
            return "kingdom";
        }

        public override void ClientHandler(IServerPlayer fromPlayer, Kingdom packet)
        {
        }

        public override void ServerHandler(Kingdom packet)
        {
            VKSystems.KingdomManager.Kingdoms.Add(packet.Id, packet);
        }
    }
}
