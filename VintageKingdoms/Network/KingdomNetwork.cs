using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintageKingdoms.Common;
using VintageKingdoms.Network.Channel;
using VintageKingdoms.Network.Packet;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace VintageKingdoms.Network
{
    public class KingdomNetwork
    {
        public static KingdomChannel KingdomChannel = new KingdomChannel();
        public static KingdomManagerChannel KingdomManagerChannel = new KingdomManagerChannel();
        public static RequestKingdomChannel RequestKingdomChannel = new RequestKingdomChannel();
        public static void RegisterClient()
        {
            KingdomChannel.RegisterClient();
            KingdomManagerChannel.RegisterClient();
            RequestKingdomChannel.RegisterClient();
        }

        public static void RegisterServer()
        {
            KingdomChannel.RegisterServer();
            KingdomManagerChannel.RegisterServer();
            RequestKingdomChannel.RegisterServer();
        }
    }
}
