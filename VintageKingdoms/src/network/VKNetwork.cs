using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintageKingdoms.Network
{
    public class VKNetwork
    {
        public static void RegisterClient()
        {
            KingdomNetwork.RegisterClient();
        }

        public static void RegisterServer()
        {
            KingdomNetwork.RegisterServer();
        }

    }
}
