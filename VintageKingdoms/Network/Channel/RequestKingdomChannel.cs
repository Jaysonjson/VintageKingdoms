using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Network.Packet;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace VintageKingdoms.Network.Channel
{
    //Client will request a Kingdom from the Server, after that Server sends the Kingdom to the client
    //Used when the Client is missing a Kingdom without the server knowing (So stuff thats called on the clientside)
    public class RequestKingdomChannel : NetworkChannel<RequestKingdomPacket>
    {
        public override string Id()
        {
            return "request_kingdom";
        }

        public override void ClientHandler(IServerPlayer fromPlayer, RequestKingdomPacket packet)
        {
            if (!VKSystems.KingdomManager.Kingdoms.ContainsKey(packet.KingdomId)) return;
            KingdomNetwork.KingdomChannel.ServerSend(VKSystems.KingdomManager.Get(packet.KingdomId), packet.Player);
        }

        public override void ServerHandler(RequestKingdomPacket packet)
        {
           
        }
    }
}
