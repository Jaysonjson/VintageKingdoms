using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace VintageKingdoms.Network.Channel
{
    //Client will request a Kingdom from the Server, after that Server sends the Kingdom to the client
    //Used when the Client is missing a Kingdom without the server knowing (So stuff thats called on the clientside)
    public class RequestKingdomChannel : NetworkChannel<int>
    {
        public override string Id()
        {
            return "request_kingdom";
        }

        public override void ClientHandler(IServerPlayer fromPlayer, int packet)
        {
            if (!VKSystems.KingdomManager.Kingdoms.ContainsKey(packet)) return;
            KingdomNetwork.KingdomChannel.ServerSend(VKSystems.KingdomManager.Get(packet), fromPlayer);
        }

        public override void ServerHandler(int packet)
        {
           
        }
    }
}
