using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace VintageKingdoms.Common
{
    public static class KingdomEvents
    {
       public static event KingdomDelegate EventKingdomCreated;
       public static event KingdomPlayerDelegate EventPlayerJoin;

       public static void FireKingdomCreated(Kingdom kingdom)
       {
            EventKingdomCreated?.Invoke(kingdom);
       }

        #nullable enable
        public static void FireEventPlayerJoin(Kingdom kingdom, IPlayer? player, string playerUid)
       {
           EventPlayerJoin?.Invoke(kingdom, player, playerUid);
       }

    }

}
