using System;
using Vintagestory.API.Common;

namespace VintageKingdoms.Common
{
    public delegate void KingdomDelegate(Kingdom kingdom);

    //TODO Implement
    #nullable enable
    public delegate void KingdomPlayerDelegate(Kingdom kingdom, IPlayer? player, String playerUid);
}
