using VintageKingdoms.Network.Channel;

namespace VintageKingdoms.Network
{
    public class KingdomNetwork
    {
        public static KingdomChannel KingdomChannel = new();
        public static KingdomManagerChannel KingdomManagerChannel = new();
        public static RequestKingdomChannel RequestKingdomChannel = new();
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
