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
    public class RequestKingdomChannel : NetworkChannel<IntegerPacket>
    {
        public override string Id()
        {
            return "request_kingdom";
        }

        public override void ClientMessageHandler(IServerPlayer fromPlayer, IntegerPacket packet)
        {
            if (!VKSystems.KingdomManager.Kingdoms.ContainsKey(packet.Data)) return;
            KingdomNetwork.KingdomChannel.ServerSend(VKSystems.KingdomManager.Get(packet.Data), fromPlayer);
        }

        public override void ServerMessageHandler(IntegerPacket packet)
        {
           
        }
    }
}
